using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using OnlineMarketingTools.Database.Data;
using OnlineMarketingTools.Database.Models;
using OnlineMarketingTools.Database.Repositories.Person_Hobby_Repo;
using OnlineMarketingTools.Database.Repositories.Person_Medical_Repo;
using OnlineMarketingTools.Database.Repositories.Person_Product_Repo;

namespace OnlineMarketingTools.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonMedicalDbContext>(options =>
                options.UseInMemoryDatabase("PersonMedicalDb"));

            services.AddDbContext<PersonHobbyDbContext>(options =>
                options.UseInMemoryDatabase("PersonHobbyDb"));

            services.AddDbContext<PersonProductDbContext>(options =>
                options.UseInMemoryDatabase("PersonProductDb"));

            //****Identity Context****
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonHobbyRepo, PersonHobbyRepo>();

            services.AddScoped<IPersonMedicalRepo, PersonMedicalRepo>();

            services.AddScoped<IPersonProductRepo, PersonProductRepo>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
