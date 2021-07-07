using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Data
{
    public class PersonMedicalDbContextTest
    {
        private readonly DbContextOptions<PersonMedicalDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonMedicalDbContext>().UseInMemoryDatabase("medical-db")
                .Options;

        private PersonMedicalDbContext GetNonRandomDataContext()
        {
            var context = new PersonMedicalDbContext(_dbOptions, false);
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
            for (var i = 0; i < medicalPersons.Count; i++)
            {
                var person = medicalPersons[i];
                Assert.Equal(MockDataGenerator.Addresses[i], person.Address);
                Assert.Equal(MockDataGenerator.Countries[i], person.Country);
                Assert.Equal(MockDataGenerator.Emails[i], person.Email);
                Assert.Equal(MockDataGenerator.FirstNames[i], person.FirstName);
                Assert.Equal(MockDataGenerator.Ids[i], person.Id);
                Assert.Equal(MockDataGenerator.LastNames[i], person.LastName);
                Assert.Equal(MockDataGenerator.MiddleNames[i], person.MiddleName);
                Assert.Equal(MockDataGenerator.PhoneNumbers[i], person.PhoneNumber);
                Assert.Equal(MockDataGenerator.PostalCodes[i], person.PostalCode);
                Assert.Equal(MockDataGenerator.MedicalEnumValues[i], person.MedicalState);
                Assert.Equal(i, person.HouseNumber);
            }

            Assert.NotEmpty(medicalPersons);
            Assert.Equal(expectedDataLength, medicalPersons.Count);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateDatabaseWithRandomData()
        {
            const int expectedDataLength = 1000;
            using var context = GetRandomDataContext(expectedDataLength);
            var medicalPersons = context.MedicalPersons.ToList();

            Assert.NotEmpty(medicalPersons);
            Assert.Equal(expectedDataLength, medicalPersons.Count);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateLiveDatabase()
        {
            using var context = GetLiveContext();
            var medicalPersons = context.MedicalPersons.ToList();

            Assert.NotNull(context.MedicalPersons);
            Assert.Empty(medicalPersons);
            context.Database.EnsureDeleted();
        }
    }
}