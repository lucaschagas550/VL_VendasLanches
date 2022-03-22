using Microsoft.EntityFrameworkCore;
using VL_VendasLanches.Context;
using VL_VendasLanches.Repositories;
using VL_VendasLanches.Repositories.Interfaces;

namespace VL_VendasLanches
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 28))));

            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. 
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
