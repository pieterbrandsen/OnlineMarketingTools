using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonProductDbContext : DbContext
	{
		private bool UseRandomData { get; }

		public PersonProductDbContext(DbContextOptions<PersonMedicalDbContext> options, bool useRandomData) : base (options)
		{
			UseRandomData = useRandomData;
		}

		public DbSet<PersonProduct> PersonProducts { get; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var productPersons = !UseRandomData
				? MockDataGenerator.PersonProductData()
				: MockDataGenerator.PersonProductRandomData();
	        
			modelBuilder.Entity<PersonProduct>().HasData(productPersons);
		}
	}
}