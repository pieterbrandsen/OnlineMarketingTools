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
                Assert.Equal(MockDataGenerator.Addresses[i], person.Address);
                Assert.Equal(MockDataGenerator.Countries[i], person.Country);
                Assert.Equal(MockDataGenerator.Emails[i], person.Email);
                Assert.Equal(MockDataGenerator.FirstNames[i], person.FirstName);
                Assert.Equal(MockDataGenerator.Ids[i], person.Id);
                Assert.Equal(MockDataGenerator.LastNames[i], person.LastName);
                Assert.Equal(MockDataGenerator.MiddleNames[i], person.MiddleName);
                Assert.Equal(MockDataGenerator.PhoneNumbers[i], person.PhoneNumber);
                Assert.Equal(MockDataGenerator.PostalCodes[i], person.PostalCode);
                Assert.Equal(MockDataGenerator.ProductGenreEnumValues[i], person.ProductGenre);
                Assert.Equal(i, person.HouseNumber);
            }

            Assert.NotEmpty(productPersons);
            Assert.Equal(expectedDataLength, productPersons.Count);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetRandomDataContext(expectedDataLength);
            var productPersons = context.PersonProducts.ToList();

            Assert.NotEmpty(productPersons);
            Assert.Equal(expectedDataLength, productPersons.Count);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateLiveDatabase()
        {
            using var context = GetLiveContext();
            var productPersons = context.PersonProducts.ToList();

            Assert.NotNull(context.PersonProducts);
            Assert.Empty(productPersons);
            context.Database.EnsureDeleted();
        }
    }
}