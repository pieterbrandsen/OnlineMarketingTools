using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonMedicalDbContextTest
    {
       private DbContextOptions<PersonMedicalDbContext> _dbOptions = new DbContextOptionsBuilder<PersonMedicalDbContext>().UseInMemoryDatabase("medical-db")
           .Options;

       private PersonMedicalDbContext GetNonRandomDataContext()
       {
           var context = new PersonMedicalDbContext(_dbOptions,false);
           return context;
       }
        
       private PersonMedicalDbContext GetRandomDataContext(int amount)
       {
           var context = new PersonMedicalDbContext(_dbOptions, true, amount);
           return context;
       }
       
       private PersonMedicalDbContext GetLiveContext()
       {
           var context = new PersonMedicalDbContext(_dbOptions);
           return context;
       }
       
        [Fact]
        public void CreateDatabaseWithoutRandomData()
        {
            const int expectedDataLength = 10;
            using var context = GetNonRandomDataContext();
            var medicalPersons = context.MedicalPersons.ToList();
            for (int i = 0; i < medicalPersons.Count; i++)
            {
                var person = medicalPersons[i];
                Assert.Equal(MockDataGenerator.addresses[i], person.Address);
                Assert.Equal(MockDataGenerator.countries[i], person.Country);
                Assert.Equal(MockDataGenerator.emails[i], person.Email);
                Assert.Equal(MockDataGenerator.firstNames[i], person.FirstName);
                Assert.Equal(MockDataGenerator.Ids[i], person.Id);
                Assert.Equal(MockDataGenerator.lastNames[i], person.LastName);
                Assert.Equal(MockDataGenerator.middleNames[i], person.MiddleName);
                Assert.Equal(MockDataGenerator.phoneNumbers[i], person.PhoneNumber);
                Assert.Equal(MockDataGenerator.postalCodes[i], person.PostalCode);
                Assert.Equal(MockDataGenerator.medicalEnumValues[i], person.MedicalState);
            }
            
            Assert.NotEmpty(medicalPersons);
            Assert.Equal(expectedDataLength, medicalPersons.Count);
        }
        
        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetRandomDataContext(expectedDataLength);
            var medicalPersons = context.MedicalPersons.ToList();
            
            Assert.NotEmpty(medicalPersons);
            Assert.Equal(expectedDataLength, medicalPersons.Count);
        }
        
        [Fact]
        public void CreateLiveDatabase()
        {
            using var context = GetLiveContext();
            var medicalPersons = context.MedicalPersons.ToList();

            Assert.NotNull(context.MedicalPersons);
            Assert.Empty(medicalPersons);
        }
    }
}