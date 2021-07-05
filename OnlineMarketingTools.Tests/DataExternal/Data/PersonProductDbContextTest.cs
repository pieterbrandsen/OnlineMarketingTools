using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonProductDbContextTest
    {
        private readonly DbContextOptions<PersonProductDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonProductDbContext>().UseInMemoryDatabase("product-db")
                .Options;

        private PersonProductDbContext GetNonRandomDataContext()
        {
            var context = new PersonProductDbContext(_dbOptions, false);
            return context;
        }

        private PersonProductDbContext GetRandomDataContext(int amount)
        {
            var context = new PersonProductDbContext(_dbOptions, true, amount);
            return context;
        }

        private PersonProductDbContext GetLiveContext()
        {
            var context = new PersonProductDbContext(_dbOptions);
            return context;
        }

        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            const int expectedDataLength = 10;
            using var context = GetNonRandomDataContext();
            var productPersons = context.PersonProducts.ToList();
            for (var i = 0; i < productPersons.Count; i++)
            {
                var person = productPersons[i];
                Assert.Equal(MockDataGenerator.addresses[i], person.Address);
                Assert.Equal(MockDataGenerator.countries[i], person.Country);
                Assert.Equal(MockDataGenerator.emails[i], person.Email);
                Assert.Equal(MockDataGenerator.firstNames[i], person.FirstName);
                Assert.Equal(MockDataGenerator.Ids[i], person.Id);
                Assert.Equal(MockDataGenerator.lastNames[i], person.LastName);
                Assert.Equal(MockDataGenerator.middleNames[i], person.MiddleName);
                Assert.Equal(MockDataGenerator.phoneNumbers[i], person.PhoneNumber);
                Assert.Equal(MockDataGenerator.postalCodes[i], person.PostalCode);
                Assert.Equal(MockDataGenerator.productGenreEnumValues[i], person.ProductGenre);
            }

            Assert.NotEmpty(productPersons);
            Assert.Equal(expectedDataLength, productPersons.Count);
        }

        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetRandomDataContext(expectedDataLength);
            var productPersons = context.PersonProducts.ToList();

            Assert.NotEmpty(productPersons);
            Assert.Equal(expectedDataLength, productPersons.Count);
        }

        [Fact]
        public void CreateLiveDatabase()
        {
            using var context = GetLiveContext();
            var productPersons = context.PersonProducts.ToList();

            Assert.NotNull(context.PersonProducts);
            Assert.Empty(productPersons);
        }
    }
}