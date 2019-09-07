using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazinga.AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SGQ.Domain.Interfaces;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using SGQ.Service.Services;

namespace ProcessosAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string credentialsUser = Configuration["ApiSecretUser"];
            string credentialsPassword = Configuration["ApiSecretPassword"];

            services.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
                .AddBasicAuthentication(credentials => Task.FromResult(
                    credentials.username == credentialsUser && credentials.password == credentialsPassword));

            services.AddDbContext<SgqContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SGQDataBase")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProcessoService, ProcessoService>();
            services.AddScoped<IAtividadeService, AtividadeService>();
            services.AddScoped<IEnumBaseService, EnumBaseService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProcessoRepository, ProcessoRepository>();
            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<IEnumBaseRepository, EnumBaseRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
