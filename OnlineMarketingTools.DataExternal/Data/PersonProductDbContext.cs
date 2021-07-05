using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonProductDbContext : DbContext
	{
		private bool UseRandomData { get; }
		private int RandomDataAmount { get; }

		public PersonProductDbContext(DbContextOptions<PersonProductDbContext> options, bool useRandomData, int 
			randomDataAmount = 1000) : base (options)
		{
			UseRandomData = useRandomData;
			RandomDataAmount = randomDataAmount;
		}

		public DbSet<PersonProduct> PersonProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var productPersons = !UseRandomData
				? MockDataGenerator.PersonProductData()
				: MockDataGenerator.PersonProductRandomData(RandomDataAmount);
	        
			modelBuilder.Entity<PersonProduct>().HasData(productPersons);
		}
	}
}