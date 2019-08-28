using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGQ.Infra.Data.Context;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using SGQ.Domain.Entities;
using SGQ.Domain.Interfaces;
using SGQ.Infra.Data.Repository;

namespace SGQ.Application
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SgqContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseSqlServer(Configuration.GetConnectionString("SGQDataBase"));
            });
                

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "1.0",
                        Title = "SGQ Api",
                        Description = "Documentação da API do SQG"
                    }
                    );
            }
            );
            services.AddDefaultIdentity<Usuario>()
                .AddEntityFrameworkStores<SgqContext>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           

            services.AddScoped<SignInManager<Usuario>, SignInManager<Usuario>>();
            services.AddScoped<UserManager<Usuario>, UserManager<Usuario>>();

            services.AddMvc().AddFluentValidation(fvc =>
                fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API SGQ");
                });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
//builder.ConfigureServices(services =>
//            {
//                // Create a new service provider.
//                var serviceProvider = new ServiceCollection()
//                    .AddEntityFrameworkInMemoryDatabase()
//                    .BuildServiceProvider();

//// Add a database context (ApplicationDbContext) using an in-memory 
//// database for testing.
//services.AddDbContext<CatalogContext>(options =>
//                {
//                    options.UseInMemoryDatabase("InMemoryDbForTesting");
//                    options.UseInternalServiceProvider(serviceProvider);
//                });

//                services.AddDbContext<AppIdentityDbContext>(options =>
//                {
//                    options.UseInMemoryDatabase("Identity");
//                    options.UseInternalServiceProvider(serviceProvider);
//                });

//                // Build the service provider.
//                var sp = services.BuildServiceProvider();

//                // Create a scope to obtain a reference to the database
//                // context (ApplicationDbContext).
//                using (var scope = sp.CreateScope())
//                {
//                    var scopedServices = scope.ServiceProvider;
//var db = scopedServices.GetRequiredService<CatalogContext>();
//var loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();

//var logger = scopedServices
//    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

//// Ensure the database is created.
//db.Database.EnsureCreated();

//                    try
//                    {
//                        // Seed the database with test data.
//                        CatalogContextSeed.SeedAsync(db, loggerFactory).Wait();
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.LogError(ex, $"An error occurred seeding the " +
//                            "database with test messages. Error: {ex.Message}");
//                    }
//                }
//            });