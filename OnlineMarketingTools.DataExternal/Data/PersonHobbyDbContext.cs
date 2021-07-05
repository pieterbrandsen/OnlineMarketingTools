using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public sealed class PersonHobbyDbContext : DbContext
	{
		private bool UseRandomData { get; }
		private int RandomDataAmount { get; }
		
		public PersonHobbyDbContext(DbContextOptions<PersonHobbyDbContext> options, bool useRandomData, int 
			randomDataAmount = 1000) : base (options)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
			UseRandomData = useRandomData;
			RandomDataAmount = randomDataAmount;
			Seed();
		}
		public PersonHobbyDbContext(DbContextOptions<PersonHobbyDbContext> options) : base (options)
		{
			Database.EnsureCreated();
		}
        public DbSet<PersonHobby> PersonHobbies { get; set; }
        
        private void Seed()
        {
	        var hobbyPersons = !UseRandomData
		        ? MockDataGenerator.PersonHobbiesData()
		        : MockDataGenerator.PersonHobbiesRandomData(RandomDataAmount);
	        
	        PersonHobbies.AddRange(hobbyPersons);
	        SaveChanges();
		}
    }
}