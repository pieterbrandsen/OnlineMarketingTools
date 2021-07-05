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