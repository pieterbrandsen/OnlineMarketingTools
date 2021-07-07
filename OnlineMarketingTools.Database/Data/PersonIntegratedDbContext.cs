using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Entities;

namespace OnlineMarketingTools.Database.Data
{
    public sealed class PersonIntegratedDbContext : DbContext
    {
        public PersonIntegratedDbContext(DbContextOptions<PersonIntegratedDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public PersonIntegratedDbContext(DbContextOptions<PersonIntegratedDbContext> options, bool useRandomData, int
            randomDataAmount = 1000) : base(options)
        {
            Database.EnsureCreated();
            UseRandomData = useRandomData;
            RandomDataAmount = randomDataAmount;
            Seed();
        }


        private bool UseRandomData { get; }
        private int RandomDataAmount { get; }
        public DbSet<PersonIntegrated> PersonsIntegrated { get; set; }

        private void Seed()
        {
            var persons = IntergratedMockDataGenerator.InterGratedPersonData();

            PersonsIntegrated.AddRange(persons);
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed();
        }
    }
}