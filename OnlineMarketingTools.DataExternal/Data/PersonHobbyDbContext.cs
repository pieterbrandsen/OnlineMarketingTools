using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonHobbyDbContext : DbContext
	{
		private bool UseRandomData { get; }
		public PersonHobbyDbContext(DbContextOptions<PersonHobbyDbContext> options, bool useRandomData) : base(options)
		{
			UseRandomData = useRandomData;
		}
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        var hobbyPersons = !UseRandomData
		        ? MockDataGenerator.PersonHobbiesData()
		        : MockDataGenerator.PersonHobbiesRandomData();
	        
	        modelBuilder.Entity<PersonHobby>().HasData(hobbyPersons);
		}
    }
}