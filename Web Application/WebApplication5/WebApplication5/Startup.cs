using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebApplication5.Services;
using WebApplication5.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DzialService>();
            services.AddSingleton<StanowiskoService>();
            services.AddSingleton<PracownikService>();
            services.AddSingleton<GodzinypracyService>();
            services.AddSingleton<WejsciaService>();
            services.AddSingleton<WyjsciaService>();
            services.AddSingleton<DzialRepository>();
            services.AddSingleton<StanowiskoRepository>();
            services.AddSingleton<PracownikRepository>();
            services.AddSingleton<GodzinypracyRepository>();
            services.AddSingleton<WejsciaRepository>();
            services.AddSingleton<WyjsciaRepository>();
            services.AddMvc();
            services.AddHttpContextAccessor();
            services.AddAuthentication(
                   CookieAuthenticationDefaults.AuthenticationScheme
               )
               .AddCookie(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   options =>
                   {
                       options.Events.OnRedirectToAccessDenied = context =>
                       {
                           context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                           return Task.CompletedTask;
                       };

                       options.Events.OnRedirectToLogin = context =>
                       {
                           context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                           return Task.CompletedTask;
                       };

                       options.LoginPath = "/login";
                       options.LogoutPath = "/logout";
                       options.SlidingExpiration = true;
                       options.ExpireTimeSpan = TimeSpan.FromSeconds(60);


                   }
               );

            services.AddAuthorization(o =>
            {
                o.AddPolicy("DefaultPolicy", b =>
                {
                    b.RequireAuthenticatedUser();
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigurationSettings.ConnectionSettings = Configuration.GetConnectionString("FirmaDatabase");
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("log.txt",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true)
            .CreateLogger();
            Log.Information("Uruchomiono aplikacjê");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Uzytkownik}/{action=Index}/{id?}");
            });
        }
    }
}
