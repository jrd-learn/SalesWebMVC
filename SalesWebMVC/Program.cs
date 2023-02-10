using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services;
using SalesWebMVC.Data;
using SalesWebMVC.Services;

namespace SalesWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SellerService>();

            var connectionStrings = builder.Configuration.GetConnectionString("SalesWebMVCContext");
            builder.Services.AddDbContext<SalesWebMVCContext>(x => x.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings)));

            var app = builder.Build();

            SeedingService.Seed(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}