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
using SGQ.Service.Services;
using SGQ.Service.Interfaces;
using SGQ.Infra.Data.Repository;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Application.Models;
using AutoMapper;
using SGQ.Domain.Interfaces;
using System.Collections.Generic;

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
                options.UseSqlServer(Configuration.GetConnectionString("SGQDataBase")));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AtividadeViewModel, Atividade>();
                cfg.CreateMap<Atividade, AtividadeViewModel>();
                cfg.CreateMap<NaoConformidadeViewModel, NaoConformidade>();
                cfg.CreateMap<NaoConformidade, NaoConformidadeViewModel>();
                cfg.CreateMap<ProcessoViewModel, Processo>();
                cfg.CreateMap<Processo, ProcessoViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

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
            services.AddScoped<IAtividadeService, AtividadeService>();
            services.AddScoped<INaoConformidadeService, NaoConformidadeService>();
            services.AddScoped<IProcessoService, ProcessoService>();
            services.AddScoped<IEnumBaseService, EnumBaseService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<INaoConformidadeRepository, NaoConformidadeRepository>();
            services.AddScoped<IProcessoRepository, ProcessoRepository>();
            services.AddScoped<IEnumBaseRepository, EnumBaseRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
