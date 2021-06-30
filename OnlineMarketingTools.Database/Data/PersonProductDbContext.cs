using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Models.Product;

namespace OnlineMarketingTools.Database.Data
{
	public class PersonProductDbContext : DbContext
	{
		public PersonProductDbContext(DbContextOptions<PersonMedicalDbContext> options) : base (options)
		{
		}

		public DbSet<PersonProduct> PersonHobbies { get; set; }

	}
}