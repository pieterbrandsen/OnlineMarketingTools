using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonMedicalDbContext : DbContext
    {
        private bool UseRandomData { get; }
        private int RandomDataAmount { get; }
		public PersonMedicalDbContext(DbContextOptions<PersonMedicalDbContext> options, bool useRandomData, int 
            randomDataAmount = 1000) : base(options)
        {
            UseRandomData = useRandomData;
            RandomDataAmount = randomDataAmount;
        }
        public DbSet<PersonMedical> MedicalPersons { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var medicalPersons = !UseRandomData
                ? MockDataGenerator.PersonMedicalData()
                : MockDataGenerator.PersonMedicalRandomData(RandomDataAmount);
	        
            modelBuilder.Entity<PersonHobby>().HasData(medicalPersons);
        }
    }
}