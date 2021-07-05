using System.IO;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public sealed class PersonProductDbContext : DbContext
	{
		private bool UseRandomData { get; }
		private int RandomDataAmount { get; }

		public PersonProductDbContext(DbContextOptions<PersonProductDbContext> options, bool useRandomData, int 
			randomDataAmount = 1000) : base (options)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
			UseRandomData = useRandomData;
			RandomDataAmount = randomDataAmount;
			Seed();
		}
		public PersonProductDbContext(DbContextOptions<PersonProductDbContext> options) : base (options)
		{
			Database.EnsureCreated();
		}

		public DbSet<PersonProduct> PersonProducts { get; set; }

		private void Seed()
		{
				var productPersons = !UseRandomData
					? MockDataGenerator.PersonProductData()
					: MockDataGenerator.PersonProductRandomData(RandomDataAmount);
		        
				PersonProducts.AddRange(productPersons);
				SaveChanges();
		}
	}
}