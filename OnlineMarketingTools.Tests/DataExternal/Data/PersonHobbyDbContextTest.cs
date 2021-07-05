using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonHobbyDbContextTest
    {
        private readonly DbContextOptions<PersonHobbyDbContext> _dbOptions = new DbContextOptionsBuilder<PersonHobbyDbContext>().UseInMemoryDatabase("hobby-db")
            .Options;
        private PersonHobbyDbContext GetContext()
        {
            var context = new PersonHobbyDbContext(_dbOptions, false);
            return context;
        }
        
        private PersonHobbyDbContext GetContext(int amount)
        {
            var context = new PersonHobbyDbContext(_dbOptions, true, amount);
            return context;
        }
        
        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            const int expectedDataLength = 10;
            using var context = GetContext();
            var hobbyPersons = context.PersonHobbies.ToList();
            for (int i = 0; i < hobbyPersons.Count; i++)
            {
                var person = hobbyPersons[i];
                Assert.Equal(MockDataGenerator.addresses[i], person.Address);
                Assert.Equal(MockDataGenerator.countries[i], person.Country);
                Assert.Equal(MockDataGenerator.emails[i], person.Email);
                Assert.Equal(MockDataGenerator.firstNames[i], person.FirstName);
                Assert.Equal(MockDataGenerator.Ids[i], person.Id);
                Assert.Equal(MockDataGenerator.lastNames[i], person.LastName);
                Assert.Equal(MockDataGenerator.middleNames[i], person.MiddleName);
                Assert.Equal(MockDataGenerator.phoneNumbers[i], person.PhoneNumber);
                Assert.Equal(MockDataGenerator.postalCodes[i], person.PostalCode);
                Assert.Equal(MockDataGenerator.hobbyEnumValues[i], person.Hobby.ToString());
            }
            
            Assert.NotEmpty(hobbyPersons);
            Assert.Equal(expectedDataLength, hobbyPersons.Count);
        }
        
        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetContext(expectedDataLength);
            var hobbyPersons = context.PersonHobbies.ToList();
            
            Assert.NotEmpty(hobbyPersons);
            Assert.Equal(expectedDataLength, hobbyPersons.Count);
        }
    }
}