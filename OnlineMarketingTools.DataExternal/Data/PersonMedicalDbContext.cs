using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonMedicalDbContext : DbContext
    {
        private bool UseRandomData { get; }
		public PersonMedicalDbContext(DbContextOptions<PersonMedicalDbContext> options, bool useRandomData) : base(options)
        {
            UseRandomData = useRandomData;
        }
        public DbSet<PersonMedical> PersonMedicals { get;  }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var medicalPersons = !UseRandomData
                ? MockDataGenerator.PersonMedicalData()
                : MockDataGenerator.PersonMedicalRandomData();
	        
            modelBuilder.Entity<PersonHobby>().HasData(medicalPersons);
        }
    }
}