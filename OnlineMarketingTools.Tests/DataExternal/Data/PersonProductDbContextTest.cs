using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonProductDbContextTest
    {
       private DbContextOptions<PersonProductDbContext> _dbOptions = new DbContextOptionsBuilder<PersonProductDbContext>().UseInMemoryDatabase("testDatabase")
           .Options;

       private PersonProductDbContext GetContext(bool useRandomData)
       {
           var context = new PersonProductDbContext(_dbOptions, useRandomData);
           context.Database.EnsureCreated();
           return context;
       }
       
        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            var context = GetContext(true);
            var medicalPersons = context.PersonProducts.ToList();
            
            Assert.NotEmpty(medicalPersons);
        }
        
        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            var context = GetContext(true);
            var medicalPersons = context.PersonProducts.ToList();
            
            Assert.NotEmpty(medicalPersons);
        }
    }
}