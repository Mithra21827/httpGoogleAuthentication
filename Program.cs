using Microsoft.AspNetCore.Authentication.Cookies;

namespace httpGoogleAuthemtication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options => {
                options.LoginPath = "/account/google-login";
            })
           .AddGoogle(options => {
               options.ClientId = "289498807575-l9s57mtmdoa0hfpgrlnp42fjc0lrp4cj.apps.googleusercontent.com";
               options.ClientSecret = "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";
           });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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