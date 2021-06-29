using Microsoft.EntityFrameworkCore;

namespace OnlineMarketingTools.Server.Data
{
	public class UserHobbyDbContext : DbContext
    {
		public UserHobbyDbContext(DbContextOptions<UserHobbyDbContext> options) : base(options)
        {
        }
    }
}