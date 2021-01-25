using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Authorization;
using Blog.Areas.Identity.Data.Seeder;
using Blog.Data.Repositories;
using Blog.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog
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
            
            /*
             * AddDbContext and AddDefaultIdentity is already specified in Areas/Identity/IdentityHostingStartUp.cs file
             */
            
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(
            //         Configuration.GetConnectionString("Connection")));
            
            // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            
            //if both cookie and token based authentication is needed
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options))
            //     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));
            
            //not needed . automatically called by app.UseAuthentication(); in configure method
            // services.AddAuthentication()
            //     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
            
            
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            
            //start: repositories
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            //end: repositories

            // all routes needs authorization if below code is used
            // services.AddAuthorization(options =>
            // {
            //     options.FallbackPolicy = new AuthorizationPolicyBuilder()
            //         .RequireAuthenticatedUser()
            //         .Build();
            // });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            
            //start custom middlewares
            app.UseWhen(
                context => context.Request.Path.StartsWithSegments("/testpath"),
                appBuilder => { appBuilder.UseRequestCulture(); }
                );
            
            //end custom middlewares
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            // Seeder.Run(app.ApplicationServices);
        }
    }
}