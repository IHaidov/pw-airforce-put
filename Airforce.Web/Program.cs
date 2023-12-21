using Alesik.Haidov.Airforce.Web.Services;
using Alesik.Haidov.Airforce.BLC;

namespace Alesik.Haidov.Airforce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Configure your BLC and services
            var blc = new BLC.BLC("airforce.sql"); // Replace with actual path or configuration
            
            builder.Services.AddSingleton(blc);
            builder.Services.AddScoped<AirbaseService>();
            builder.Services.AddScoped<AircraftService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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