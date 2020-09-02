using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace LiveClinic.ClinicManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.Console(LogEventLevel.Debug)
                .WriteTo.File("logs/clinicsvc-.log", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information($"Starting Clinic Manger...");
                ;
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(GetConfig(args));
                    webBuilder.UseStartup<Startup>();
                });

        private static IConfigurationRoot GetConfig(string[] args)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("hosting.json", optional: true)
                .AddCommandLine(args).Build();
        }
    }
}
