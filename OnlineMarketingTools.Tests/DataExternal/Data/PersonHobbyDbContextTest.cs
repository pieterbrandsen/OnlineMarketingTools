using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonHobbyDbContextTest
    {
        private readonly DbContextOptions<PersonHobbyDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonHobbyDbContext>().UseInMemoryDatabase("hobby-db")
                .Options;

        private PersonHobbyDbContext GetNonRandomDataContext()
        {
            var context = new PersonHobbyDbContext(_dbOptions, false);
            return context;
        }

        private PersonHobbyDbContext GetRandomDataContext(int amount)
        {
            var context = new PersonHobbyDbContext(_dbOptions, true, amount);
            return context;
        }

        private PersonHobbyDbContext GetLiveContext()
        {
            var context = new PersonHobbyDbContext(_dbOptions);
            return context;
        }

        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            const int expectedDataLength = 10;
            using var context = GetNonRandomDataContext();
            var hobbyPersons = context.PersonHobbies.ToList();
            for (var i = 0; i < hobbyPersons.Count; i++)
            {
                var person = hobbyPersons[i];
                Assert.Equal(MockDataGenerator.Addresses[i], person.Address);
                Assert.Equal(MockDataGenerator.Countries[i], person.Country);
                Assert.Equal(MockDataGenerator.Emails[i], person.Email);
                Assert.Equal(MockDataGenerator.FirstNames[i], person.FirstName);
                Assert.Equal(MockDataGenerator.Ids[i], person.Id);
                Assert.Equal(MockDataGenerator.LastNames[i], person.LastName);
                Assert.Equal(MockDataGenerator.MiddleNames[i], person.MiddleName);
                Assert.Equal(MockDataGenerator.PhoneNumbers[i], person.PhoneNumber);
                Assert.Equal(MockDataGenerator.PostalCodes[i], person.PostalCode);
                Assert.Equal(MockDataGenerator.HobbyEnumValues[i], person.Hobby);
                Assert.Equal(i, person.HouseNumber);
            }

            Assert.NotEmpty(hobbyPersons);
            Assert.Equal(expectedDataLength, hobbyPersons.Count);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetRandomDataContext(expectedDataLength);
            var hobbyPersons = context.PersonHobbies.ToList();

            Assert.NotEmpty(hobbyPersons);
            Assert.Equal(expectedDataLength, hobbyPersons.Count);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateLiveDatabase()
        {
            using var context = GetLiveContext();
            var hobbyPersons = context.PersonHobbies.ToList();

            Assert.NotNull(context.PersonHobbies);
            Assert.Empty(hobbyPersons);
            context.Database.EnsureDeleted();
        }
    }
}