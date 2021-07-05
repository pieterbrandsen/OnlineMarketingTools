using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonHobbyDbContext : DbContext
	{
		private bool UseRandomData { get; }
		private int RandomDataAmount { get; }
		public PersonHobbyDbContext(DbContextOptions<PersonHobbyDbContext> options, bool useRandomData, int 
			randomDataAmount = 1000) : base(options)
		{
			UseRandomData = useRandomData;
			RandomDataAmount = randomDataAmount;
		}
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        var hobbyPersons = !UseRandomData
		        ? MockDataGenerator.PersonHobbiesData()
		        : MockDataGenerator.PersonHobbiesRandomData(RandomDataAmount);
	        
	        modelBuilder.Entity<PersonHobby>().HasData(hobbyPersons);
		}
    }
}