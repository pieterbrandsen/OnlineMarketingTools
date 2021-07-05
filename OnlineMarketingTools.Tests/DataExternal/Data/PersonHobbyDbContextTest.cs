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