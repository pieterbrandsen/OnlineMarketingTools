using System.Linq;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonProductDbContextTest
    {
        private readonly DbContextOptions<PersonProductDbContext> _dbOptions = new DbContextOptionsBuilder<PersonProductDbContext>().UseInMemoryDatabase("product-db")
            .Options;
        private PersonProductDbContext GetContext()
        {
            var context = new PersonProductDbContext(_dbOptions, false);
            return context;
        }
        
        private PersonProductDbContext GetContext(int amount)
        {
            var context = new PersonProductDbContext(_dbOptions, true, amount);
            return context;
        }
       
        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            const int expectedDataLength = 10;
            using var context = GetContext();
            var productPersons = context.PersonProducts.ToList();
            for (int i = 0; i < productPersons.Count; i++)
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
                Assert.Equal(MockDataGenerator.productGenreEnumValues[i], person.ProductGenre.ToString());
            }
            
            Assert.NotEmpty(productPersons);
            Assert.Equal(expectedDataLength, productPersons.Count);
        }
        
        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetContext(expectedDataLength);
            var productPersons = context.PersonProducts.ToList();

            Assert.NotEmpty(productPersons);
            Assert.Equal(expectedDataLength, productPersons.Count);
        }
    }
}