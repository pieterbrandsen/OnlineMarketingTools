using Microsoft.EntityFrameworkCore;

namespace OnlineMarketingTools.Server.Data
{
	public class UserProductsDbContext : DbContext
	{
		public UserProductsDbContext(DbContextOptions<UserMedicalDbContext> options) : base (options)
		{
		}
	}
}