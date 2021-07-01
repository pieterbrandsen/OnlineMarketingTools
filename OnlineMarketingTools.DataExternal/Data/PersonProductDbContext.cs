using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
	public class PersonProductDbContext : DbContext
	{
		public PersonProductDbContext(DbContextOptions<PersonMedicalDbContext> options) : base (options)
		{
		}

		public DbSet<PersonProduct> PersonHobbies { get; set; }

	}
}