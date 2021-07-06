using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Entities;

namespace OnlineMarketingTools.Database.Data
{
    public sealed class PersonIntegratedDbContext : DbContext
    {
        public PersonIntegratedDbContext(DbContextOptions<PersonIntegratedDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PersonIntegrated> PersonsIntegrated { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}