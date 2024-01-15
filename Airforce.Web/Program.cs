using Alesik.Haidov.Airforce.Web.Services;
using Alesik.Haidov.Airforce.BLC;
using Alesik.Haidov.Airforce.Interfaces;
using Alesik.Haidov.Airforce.DBSQL;

namespace Alesik.Haidov.Airforce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<DAOSQL>();
            var dataSource = builder.Configuration.GetValue<string>("ConnectionStrings:DataSource");

            builder.Services.AddSingleton<BLC.BLC>();
            builder.Services.AddScoped<AirbaseService>(provider => new AirbaseService(provider.GetRequiredService<BLC.BLC>(), dataSource));
            builder.Services.AddScoped<AircraftService>(provider => new AircraftService(provider.GetRequiredService<BLC.BLC>(), dataSource));

            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
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

            app.MapRazorPages();

            app.Run();
        }
    }
}