using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Entities;

namespace OnlineMarketingTools.Database.Data
{
	public class PersonIntegratedDbContext : DbContext
    {
		public PersonIntegratedDbContext(DbContextOptions<PersonIntegratedDbContext> options) : base(options)
        {
        }
        public DbSet<PersonIntegrated> PersonsIntegrated { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }


    }
}