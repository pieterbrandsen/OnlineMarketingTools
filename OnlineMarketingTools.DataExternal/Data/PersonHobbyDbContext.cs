using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonHobbyDbContext : DbContext
    {
		public PersonHobbyDbContext(DbContextOptions<PersonHobbyDbContext> options) : base(options)
        {
        }
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        var hobbyPersons = MockDataGenerator.PersonHobbiesData(100);
	        modelBuilder.Entity<PersonHobby>().HasData(hobbyPersons);
        }
    }
}