using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Models.Medical;

namespace OnlineMarketingTools.Database.Data
{
	public class PersonMedicalDbContext : DbContext
    {
		public PersonMedicalDbContext(DbContextOptions<PersonMedicalDbContext> options) : base(options)
        {
        }
        public DbSet<PersonMedical> PersonMedicals { get; set; }
    }
}