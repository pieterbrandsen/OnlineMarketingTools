using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonHobbyDbContextTest
    {
        private DbContextOptions<PersonHobbyDbContext> _dbOptions = new DbContextOptionsBuilder<PersonHobbyDbContext>().UseInMemoryDatabase("testDatabase")
            .Options;

        private PersonHobbyDbContext GetContext(bool useRandomData)
        {
            var context = new PersonHobbyDbContext(_dbOptions, useRandomData);
            context.Database.EnsureCreated();
            return context;
        }
        
        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            var context = GetContext(false);
            var hobbyPersons = context.PersonHobbies.ToList();
            
            Assert.NotEmpty(hobbyPersons);
        }
        
        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            var context = GetContext(true);
            var hobbyPersons = context.PersonHobbies.ToList();
            
            Assert.NotEmpty(hobbyPersons);
        }
    }
}