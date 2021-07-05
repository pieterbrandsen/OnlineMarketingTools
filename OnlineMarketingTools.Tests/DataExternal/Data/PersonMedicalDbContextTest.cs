using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonMedicalDbContextTest
    {
       private DbContextOptions<PersonMedicalDbContext> _dbOptions = new DbContextOptionsBuilder<PersonMedicalDbContext>().UseInMemoryDatabase("testDatabase")
           .Options;

       private PersonMedicalDbContext GetContext(bool useRandomData)
       {
           var context = new PersonMedicalDbContext(_dbOptions, useRandomData);
           context.Database.EnsureCreated();
           return context;
       }
       
        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            var context = GetContext(true);
            var medicalPersons = context.MedicalPersons.ToList();
            
            Assert.NotEmpty(medicalPersons);
        }
        
        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            var context = GetContext(true);
            var medicalPersons = context.MedicalPersons.ToList();
            
            Assert.NotEmpty(medicalPersons);
        }
    }
}