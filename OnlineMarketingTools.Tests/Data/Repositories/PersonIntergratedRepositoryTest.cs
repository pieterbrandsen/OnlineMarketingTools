using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.Database.Data;
using OnlineMarketingTools.Database.Repositories;
using OnlineMarketingTools.DataExternal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static IdentityServer4.Models.IdentityResources;

namespace OnlineMarketingTools.Tests.Data.Repositories
{
    public class PersonIntergratedRepositoryTest
    {
        private readonly DbContextOptions<PersonIntegratedDbContext> _dbOptions1 =
            new DbContextOptionsBuilder<PersonIntegratedDbContext>().UseInMemoryDatabase("personintergratedSeeded-db")
                .Options;

        private readonly DbContextOptions<PersonIntegratedDbContext> _dbOptions2 =
            new DbContextOptionsBuilder<PersonIntegratedDbContext>().UseInMemoryDatabase("personintergratedEmpty-db")
                .Options;

        private readonly PersonIntegratedDbContext _seededContext;
        private readonly IPersonIntegratedRepository _personRepoSeeded;

        private readonly PersonIntegrated _expectedPerson;

        public PersonIntergratedRepositoryTest()
        {
            _seededContext = new PersonIntegratedDbContext(_dbOptions1, false);
            _personRepoSeeded = new PersonIntegratedRepositoy(_seededContext);

            _expectedPerson = new PersonIntegrated()
            {
                Id = MockDataGenerator.Ids[0],
                Adress = MockDataGenerator.Addresses[0],
                Country = MockDataGenerator.Countries[0],
                Email = MockDataGenerator.Emails[0],
                FirstName = MockDataGenerator.FirstNames[0],
                Hobby = MockDataGenerator.HobbyEnumValues[0].ToString(),
                HouseNumber = 0,
                LastName = MockDataGenerator.LastNames[0],
                MedicalState = MockDataGenerator.MedicalEnumValues[0].ToString(),
                MiddleName = MockDataGenerator.MiddleNames[0],
                PhoneNumber = MockDataGenerator.PhoneNumbers[0],
                PostCode = MockDataGenerator.PostalCodes[0],
                ProductGenre = MockDataGenerator.ProductGenreEnumValues[0].ToString()
            };
        }

        [Fact]
        public async Task GetByFirstNameLastNameAndPostCode()
        {
            using (_seededContext)
            {
                var firstName = MockDataGenerator.FirstNames[0];
                var lastName = MockDataGenerator.LastNames[0];
                var postCode = MockDataGenerator.PostalCodes[0];

                var result = await _personRepoSeeded.GetByFirstNameLastNameAndPostCode(firstName, lastName, postCode);

                Assert.Equal(_expectedPerson.FirstName, result.FirstName);
                Assert.Equal(_expectedPerson.MiddleName, result.MiddleName);
                Assert.Equal(_expectedPerson.LastName, result.LastName);
                Assert.Equal(_expectedPerson.Id, result.Id);
                Assert.Equal(_expectedPerson.MedicalState, result.MedicalState);
                Assert.Equal(_expectedPerson.ProductGenre, result.ProductGenre);
                Assert.Equal(_expectedPerson.Hobby, result.Hobby);
                Assert.Equal(_expectedPerson.HouseNumber, result.HouseNumber);
                Assert.Equal(_expectedPerson.Email, result.Email);
                Assert.Equal(_expectedPerson.Country, result.Country);
                Assert.Equal(_expectedPerson.PhoneNumber, result.PhoneNumber);

                await _seededContext.Database.EnsureDeletedAsync();
            }
        }

        [Fact]
        public async Task GetByIdTest()
        {
            using (var context = new PersonIntegratedDbContext(_dbOptions1, false))
            {
                PersonIntegrated result;
                using (var repo = new PersonIntegratedRepositoy(context))
                {
                    result = await _personRepoSeeded.GetById(MockDataGenerator.Ids[0]);
                }

                Assert.Equal(_expectedPerson.FirstName, result.FirstName);
                Assert.Equal(_expectedPerson.MiddleName, result.MiddleName);
                Assert.Equal(_expectedPerson.LastName, result.LastName);
                Assert.Equal(_expectedPerson.Id, result.Id);
                Assert.Equal(_expectedPerson.MedicalState, result.MedicalState);
                Assert.Equal(_expectedPerson.ProductGenre, result.ProductGenre);
                Assert.Equal(_expectedPerson.Hobby, result.Hobby);
                Assert.Equal(_expectedPerson.HouseNumber, result.HouseNumber);
                Assert.Equal(_expectedPerson.Email, result.Email);
                Assert.Equal(_expectedPerson.Country, result.Country);
                Assert.Equal(_expectedPerson.PhoneNumber, result.PhoneNumber);

                await context.Database.EnsureDeletedAsync();
            }
        }

        [Fact]
        public async Task AddPersonTest()
        {
            await using var context = new PersonIntegratedDbContext(_dbOptions2);
            var person = new PersonIntegrated()
            {
                Id = MockDataGenerator.Ids[0],
                Adress = MockDataGenerator.Addresses[0],
                Country = MockDataGenerator.Countries[0],
                Email = MockDataGenerator.Emails[0],
                FirstName = MockDataGenerator.FirstNames[0],
                Hobby = MockDataGenerator.HobbyEnumValues[0].ToString(),
                HouseNumber = 0,
                LastName = MockDataGenerator.LastNames[0],
                MedicalState = MockDataGenerator.MedicalEnumValues[0].ToString(),
                MiddleName = MockDataGenerator.MiddleNames[0],
                PhoneNumber = MockDataGenerator.PhoneNumbers[0],
                PostCode = MockDataGenerator.PostalCodes[0],
                ProductGenre = MockDataGenerator.ProductGenreEnumValues[0].ToString()
            };

            bool taskResult;

            using (var repo = new PersonIntegratedRepositoy(context))
            {
                taskResult = await repo.AddPerson(person);
            }

            Assert.True(taskResult);

            Assert.Equal(1, context.PersonsIntegrated.Count());

            await context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task AddRangeTest()
        {
            await using var context = new PersonIntegratedDbContext(_dbOptions2);
            var personList = new List<PersonIntegrated>();
            for (int i = 0; i <= 2; i++)
            {
                var person = new PersonIntegrated()
                {
                    Id = MockDataGenerator.Ids[i],
                    Adress = MockDataGenerator.Addresses[i],
                    Country = MockDataGenerator.Countries[i],
                    Email = MockDataGenerator.Emails[i],
                    FirstName = MockDataGenerator.FirstNames[i],
                    Hobby = MockDataGenerator.HobbyEnumValues[i].ToString(),
                    HouseNumber = i,
                    LastName = MockDataGenerator.LastNames[i],
                    MedicalState = MockDataGenerator.MedicalEnumValues[i].ToString(),
                    MiddleName = MockDataGenerator.MiddleNames[i],
                    PhoneNumber = MockDataGenerator.PhoneNumbers[i],
                    PostCode = MockDataGenerator.PostalCodes[i],
                    ProductGenre = MockDataGenerator.ProductGenreEnumValues[i].ToString()
                };
                personList.Add(person);
            }

            bool result;

            using (var repo = new PersonIntegratedRepositoy(context))
            {
                result = await repo.AddRange(personList);
            }

            Assert.True(result);

            Assert.Equal(3, context.PersonsIntegrated.Count());

            await context.Database.EnsureDeletedAsync();
        }


        //public Task<bool> UpdatePerson(PersonIntegrated PersonToUpdate);
        //public Task<bool> UpdateRange(IEnumerable<PersonIntegrated> PeopleToUpdate);
    }
}
