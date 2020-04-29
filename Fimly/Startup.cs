using BlazorAnimate;
using Blazored.Toast;
using Fimly.Areas.Identity;
using Fimly.Data;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Fimly
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IHostEnvironment CurrentEnvironment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // use default mysql settings if none are specified in docker environment variables
            string host = Configuration["DB_HOST"] ?? "localhost";
            string port = Configuration["DB_PORT"] ?? "3306";
            string dbUser = Configuration["DB_USER"] ?? "fimly_user";
            string dbPassword = Configuration["DB_PASSWORD"] ?? "fimly_secret";
            string dbName = Configuration["DB_DATABASE"] ?? "fimly_db";

            // use mysql dev server if in development
            if (CurrentEnvironment.IsDevelopment())
            {
                host = "192.168.1.34";
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql($"server={host}; userid={dbUser}; pwd={dbPassword}; port={port}; database={dbName}",
                    providerOptions => providerOptions.EnableRetryOnFailure()),
                ServiceLifetime.Transient
            );

            services.AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddTransient<AccountService>();
            services.AddTransient<ConfigService>();
            services.AddTransient<CurrencyService>();
            services.AddTransient<ExpenseService>();
            services.AddTransient<ExpenseTypeService>();
            services.AddTransient<PersonService>();

            services.AddBlazoredToast();

            services.Configure<AnimateOptions>(options =>
            {
                options.Animation = Animations.FadeIn;
                options.Duration = TimeSpan.FromSeconds(0.5);
                options.Once = true;
            });
        }

        public void Configure(IApplicationBuilder app,
            ApplicationDbContext dbContext)
        {
            if (CurrentEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            dbContext.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
