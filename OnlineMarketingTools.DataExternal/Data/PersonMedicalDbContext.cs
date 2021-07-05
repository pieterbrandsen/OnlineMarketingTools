using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
    public sealed class PersonMedicalDbContext : DbContext
    {
        public PersonMedicalDbContext(DbContextOptions<PersonMedicalDbContext> options, bool useRandomData, int
            randomDataAmount = 1000) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            UseRandomData = useRandomData;
            RandomDataAmount = randomDataAmount;
            Seed();
        }

        public PersonMedicalDbContext(DbContextOptions<PersonMedicalDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        private bool UseRandomData { get; }
        private int RandomDataAmount { get; }
        public DbSet<PersonMedical> MedicalPersons { get; set; }

        private void Seed()
        {
            var medicalPersons = !UseRandomData
                ? MockDataGenerator.PersonMedicalData()
                : MockDataGenerator.PersonMedicalRandomData(RandomDataAmount);

            MedicalPersons.AddRange(medicalPersons);
            SaveChanges();
        }
    }
}