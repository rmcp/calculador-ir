using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using calculator_api.Repository;
using Microsoft.EntityFrameworkCore;
using calculator_api.Services;
using calculator_api.Data;

namespace calculator_api
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
            //services.AddDbContext<CalculatorContext>(opt =>
            //   opt.UseInMemoryDatabase("CalculadorIR"));

            services.AddDbContext<CalculatorContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddScoped<ICalculoIRRepository, CalculoIRRepository>();
            services.AddScoped<ICalculadorIRService, CalculadorIRPessoaFisicaService>();

            services.AddScoped<IAliquotaRepository, AliquotaRepository>();
            services.AddScoped<IAliquotaService, AliquotaService>();

            services.AddScoped<ICalculoIRRepository, CalculoIRRepository>();
            services.AddScoped<ICalculoIRService, CalculoIRService>();

            services.AddScoped<IContribuinteRepository, ContribuinteRepository>();
            services.AddScoped<IContribuinteService, ContribuinteService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
