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
    }
}