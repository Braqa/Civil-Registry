using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegjistriCivil.Models;

namespace RegjistriCivil
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
            services.AddControllersWithViews();
            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            // Configuring Identity services
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            // Configuring Claims based authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateIdCardPolicy", policy => policy.RequireClaim("Create Id Card"));
                options.AddPolicy("EditIdCardPolicy", policy => policy.RequireClaim("Edit Id Card"));
                options.AddPolicy("DeleteIdCardPolicy", policy => policy.RequireClaim("Delete Id Card"));
                options.AddPolicy("CreatePassportPolicy", policy => policy.RequireClaim("Create Passport"));
                options.AddPolicy("EditPassportPolicy", policy => policy.RequireClaim("Edit Passport"));
                options.AddPolicy("DeletePassportPolicy", policy => policy.RequireClaim("Delete Passport"));
                options.AddPolicy("CreateCertificatePolicy", policy => policy.RequireClaim("Create Certificate"));
                options.AddPolicy("EditCertificatePolicy", policy => policy.RequireClaim("Edit Certificate"));
                options.AddPolicy("DeleteCertificatePolicy", policy => policy.RequireClaim("Delete Certificate"));
                options.AddPolicy("CreateRolePolicy", policy => policy.RequireClaim("Create Role"));
                options.AddPolicy("EditRolePolicy", policy => policy.RequireClaim("Edit Role"));
                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));
                options.AddPolicy("CreateUserPolicy", policy => policy.RequireClaim("Create User"));
                options.AddPolicy("EditUserPolicy", policy => policy.RequireClaim("Edit User"));
                options.AddPolicy("DeleteUserPolicy", policy => policy.RequireClaim("Delete User"));
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            // Identity Middleware
            app.UseAuthentication();

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
