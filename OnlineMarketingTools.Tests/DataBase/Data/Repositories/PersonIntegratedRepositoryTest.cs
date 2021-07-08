using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.Database.Data;
using OnlineMarketingTools.Database.Repositories;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataBase.Data.Repositories
{
    public class TestHelper : IDisposable
    {
        private readonly DbContextOptions<PersonIntegratedDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonIntegratedDbContext>().UseInMemoryDatabase("db")
                .Options;

        public PersonIntegratedDbContext DbContext { get; private set; }
        public IPersonIntegratedRepository Repo { get; private set; }

        public TestHelper()
        {
            DbContext = new PersonIntegratedDbContext(_dbOptions, false);
            Repo = new PersonIntegratedRepositoy(DbContext);
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
        }

        public async void DisposeAsync()
        {
            await DbContext.Database.EnsureDeletedAsync();
        }
    }

    public class PersonIntegratedRepositoryTest : TestHelper
    {
        private readonly PersonIntegrated _expectedPerson;

        public PersonIntegratedRepositoryTest()
        {
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
            var firstName = _expectedPerson.FirstName;
            var lastName = _expectedPerson.LastName;
            var postCode = _expectedPerson.PostCode;

            var person = await Repo.GetByFirstNameLastNameAndPostCodeAsync(firstName, lastName, postCode);
            Assert.Equal(_expectedPerson.FirstName, person.FirstName);
            Assert.Equal(_expectedPerson.MiddleName, person.MiddleName);
            Assert.Equal(_expectedPerson.LastName, person.LastName);
            Assert.Equal(_expectedPerson.Id, person.Id);
            Assert.Equal(_expectedPerson.MedicalState, person.MedicalState);
            Assert.Equal(_expectedPerson.ProductGenre, person.ProductGenre);
            Assert.Equal(_expectedPerson.Hobby, person.Hobby);
            Assert.Equal(_expectedPerson.HouseNumber, person.HouseNumber);
            Assert.Equal(_expectedPerson.Email, person.Email);
            Assert.Equal(_expectedPerson.Country, person.Country);
            Assert.Equal(_expectedPerson.PhoneNumber, person.PhoneNumber);
            Assert.Equal(_expectedPerson.Adress, person.Adress);
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var person = await Repo.GetByIdAsync(_expectedPerson.Id);

            Assert.Equal(_expectedPerson.FirstName, person.FirstName);
            Assert.Equal(_expectedPerson.MiddleName, person.MiddleName);
            Assert.Equal(_expectedPerson.LastName, person.LastName);
            Assert.Equal(_expectedPerson.Id, person.Id);
            Assert.Equal(_expectedPerson.MedicalState, person.MedicalState);
            Assert.Equal(_expectedPerson.ProductGenre, person.ProductGenre);
            Assert.Equal(_expectedPerson.Hobby, person.Hobby);
            Assert.Equal(_expectedPerson.HouseNumber, person.HouseNumber);
            Assert.Equal(_expectedPerson.Email, person.Email);
            Assert.Equal(_expectedPerson.Country, person.Country);
            Assert.Equal(_expectedPerson.PhoneNumber, person.PhoneNumber);
            Assert.Equal(_expectedPerson.Adress, person.Adress);
        }

        [Fact]
        public async Task AddPersonTest()
        {
            var oldId = _expectedPerson.Id;
            var oldFirstName = _expectedPerson.FirstName;
            _expectedPerson.Id = 100;
            _expectedPerson.FirstName = "aaa";
            var taskSuccess = await Repo.AddAsync(_expectedPerson);
            _expectedPerson.Id = oldId;
            _expectedPerson.FirstName = oldFirstName;

            Assert.True(taskSuccess);
            Assert.Equal(11, DbContext.PersonsIntegrated.Count());
        }

        [Fact]
        public async Task AddRangeTest()
        {
            var personList = new List<PersonIntegrated>();
            for (var i = 0; i <= 2; i++)
            {
                var person = new PersonIntegrated()
                {
                    Id = MockDataGenerator.Ids[i] + 10,
                    Adress = MockDataGenerator.Addresses[i],
                    Country = MockDataGenerator.Countries[i],
                    Email = MockDataGenerator.Emails[i],
                    FirstName = MockDataGenerator.FirstNames[i],
                    Hobby = MockDataGenerator.HobbyEnumValues[i].ToString(),
                    HouseNumber = i,
                    LastName = MockDataGenerator.LastNames[i] + "aaa",
                    MedicalState = MockDataGenerator.MedicalEnumValues[i].ToString(),
                    MiddleName = MockDataGenerator.MiddleNames[i],
                    PhoneNumber = MockDataGenerator.PhoneNumbers[i],
                    PostCode = MockDataGenerator.PostalCodes[i],
                    ProductGenre = MockDataGenerator.ProductGenreEnumValues[i].ToString()
                };
                personList.Add(person);
            }

            var result = await Repo.AddRangeAsync(personList);

            Assert.True(result);
            Assert.Equal(13, DbContext.PersonsIntegrated.Count());
        }


        //public Task<bool> UpdatePerson(PersonIntegrated PersonToUpdate);
        //public Task<bool> UpdateRange(IEnumerable<PersonIntegrated> PeopleToUpdate);
    }
}