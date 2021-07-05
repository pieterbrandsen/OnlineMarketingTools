using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonMedicalDbContext : DbContext
    {
		public PersonMedicalDbContext(DbContextOptions<PersonMedicalDbContext> options) : base(options)
        {
        }
        public DbSet<PersonMedical> PersonMedicals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // var medicalPersons = MockDataGenerator.PersonMedicalData(100);
            // modelBuilder.Entity<PersonMedical>().HasData(medicalPersons);
        }
    }
}