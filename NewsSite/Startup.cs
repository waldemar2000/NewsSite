using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsSite.Data;
using System.Linq;
using System;

namespace NewsSite
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("HiddenNews", policy => policy.RequireClaim("role", "subscriber", "administrator", "publisher"));

                options.AddPolicy("AdultNews", policy => policy.RequireAssertion(context =>
                {
                    var currentUser = context.User;

                    if (currentUser.HasClaim("role", "publisher") || currentUser.HasClaim("role", "administrator"))
                    {
                        return true;
                    }

                    else if (currentUser.HasClaim("role", "subscriber"))
                    {
                        var claims = currentUser.Claims.ToList();
                        foreach (var x in claims)
                        {
                            if (x.Type == "age")
                            { 
                                Int32.TryParse(x.Value, out int y);
                                if (y > 18)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }

                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

