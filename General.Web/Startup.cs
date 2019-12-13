using General.Entities;
using General.Entities.GeneralModels;
using General.NetCore.Data;
using General.Services.General.EntityServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using General.NetCore.Extensions;
namespace General.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Defaultconnection")));
            //单个注入
           // services.AddTransient<ICategoryService,CategoryService>();
            //泛型注入
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //程序集注入
            services.AddAssembly("General.Services");
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
