using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Models.Hobby;

namespace OnlineMarketingTools.Database.Data
{
	public class PersonHobbyDbContext : DbContext
    {
		public PersonHobbyDbContext(DbContextOptions<PersonHobbyDbContext> options) : base(options)
        {
        }
        public DbSet<PersonHobby> PersonHobbies { get; set; }

    }
}