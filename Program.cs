using FluentWay.EntityFramework.DbContexts;
using FluentWay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FluentWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("School")));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AccountContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddIdentityApiEndpoints<User>();
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "Register",
            //    pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
