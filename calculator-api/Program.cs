using System;
using calculator_api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging;
using Serilog;

namespace calculator_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                var host = CreateHostBuilder(args).Build();

                CreateDbIfNotExists(host);

                Log.Information("Iniciando Web Host");

                host.Run();

            } catch(Exception ex)
            {

                Log.Fatal(ex, "Host encerrado inesperadamente");                
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CalculatorContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var settings = config.Build();
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.MongoDB(settings.GetConnectionString("LogDatabase"), collectionName: "calulator_api_logging")
                        .CreateLogger();
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
}
