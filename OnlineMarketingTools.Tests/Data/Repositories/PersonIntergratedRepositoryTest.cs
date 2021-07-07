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
        private readonly DbContextOptions<PersonIntegratedDbContext> dbOptions1 =
            new DbContextOptionsBuilder<PersonIntegratedDbContext>().UseInMemoryDatabase("personintergratedSeeded-db")
                .Options;

        private readonly DbContextOptions<PersonIntegratedDbContext> dbOptions2 =
            new DbContextOptionsBuilder<PersonIntegratedDbContext>().UseInMemoryDatabase("personintergratedEmpty-db")
                .Options;

        private readonly PersonIntegratedDbContext seededContext;
        private readonly IPersonIntegratedRepository PersonRepoSeeded;

        private readonly PersonIntegrated ExpectedPerson;

        public PersonIntergratedRepositoryTest()
        {
            seededContext = new PersonIntegratedDbContext(dbOptions1, false);
            PersonRepoSeeded = new PersonIntegratedRepositoy(seededContext);

            ExpectedPerson = new PersonIntegrated()
            {
                Key = MockDataGenerator.Ids[0],
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
            using (seededContext)
            {
                var firstName = MockDataGenerator.FirstNames[0];
                var lastName = MockDataGenerator.LastNames[0];
                var postCode = MockDataGenerator.PostalCodes[0];

                var result = await PersonRepoSeeded.GetByFirstNameLastNameAndPostCode(firstName, lastName, postCode);

                Assert.Equal(ExpectedPerson.FirstName, result.FirstName);
                Assert.Equal(ExpectedPerson.MiddleName, result.MiddleName);
                Assert.Equal(ExpectedPerson.LastName, result.LastName);
                Assert.Equal(ExpectedPerson.Key, result.Key);
                Assert.Equal(ExpectedPerson.MedicalState, result.MedicalState);
                Assert.Equal(ExpectedPerson.ProductGenre, result.ProductGenre);
                Assert.Equal(ExpectedPerson.Hobby, result.Hobby);
                Assert.Equal(ExpectedPerson.HouseNumber, result.HouseNumber);
                Assert.Equal(ExpectedPerson.Email, result.Email);
                Assert.Equal(ExpectedPerson.Country, result.Country);
                Assert.Equal(ExpectedPerson.PhoneNumber, result.PhoneNumber);

                seededContext.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task GetByIdTest()
        {
            using (var context = new PersonIntegratedDbContext(dbOptions1, false))
            {
                PersonIntegrated result;
                using (var repo = new PersonIntegratedRepositoy(context))
                {
                    result = await PersonRepoSeeded.GetById(MockDataGenerator.Ids[0]);
                }

                Assert.Equal(ExpectedPerson.FirstName, result.FirstName);
                Assert.Equal(ExpectedPerson.MiddleName, result.MiddleName);
                Assert.Equal(ExpectedPerson.LastName, result.LastName);
                Assert.Equal(ExpectedPerson.Key, result.Key);
                Assert.Equal(ExpectedPerson.MedicalState, result.MedicalState);
                Assert.Equal(ExpectedPerson.ProductGenre, result.ProductGenre);
                Assert.Equal(ExpectedPerson.Hobby, result.Hobby);
                Assert.Equal(ExpectedPerson.HouseNumber, result.HouseNumber);
                Assert.Equal(ExpectedPerson.Email, result.Email);
                Assert.Equal(ExpectedPerson.Country, result.Country);
                Assert.Equal(ExpectedPerson.PhoneNumber, result.PhoneNumber);

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task AddPersonTest()
        {
            using (var context = new PersonIntegratedDbContext(dbOptions2))
            {
                var person = new PersonIntegrated()
                {
                    Key = MockDataGenerator.Ids[0],
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

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task AddRangeTest()
        {
            using (var context = new PersonIntegratedDbContext(dbOptions2))
            {
                var personList = new List<PersonIntegrated>();
                for (int i = 0; i <= 2; i++)
                {
                    var person = new PersonIntegrated()
                    {
                        Key = MockDataGenerator.Ids[i],
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

                context.Database.EnsureDeleted();
            }
        }


        //public Task<bool> UpdatePerson(PersonIntegrated PersonToUpdate);
        //public Task<bool> UpdateRange(IEnumerable<PersonIntegrated> PeopleToUpdate);
    }
}
