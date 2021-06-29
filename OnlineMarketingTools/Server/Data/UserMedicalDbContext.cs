using Microsoft.EntityFrameworkCore;

namespace OnlineMarketingTools.Server.Data
{
	public class UserMedicalDbContext : DbContext
    {
		public UserMedicalDbContext(DbContextOptions<UserMedicalDbContext> options) : base(options)
        {
        }
    }
}