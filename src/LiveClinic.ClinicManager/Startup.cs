using System.Collections.Generic;
using System.Reflection;
using LiveClinic.ClinicManager.Core;
using LiveClinic.ClinicManager.Core.Domain.Clients;
using LiveClinic.ClinicManager.Infrastructure;
using LiveClinic.ClinicManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LiveClinic.ClinicManager
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructure(Configuration,GetAppAssemblies());
            services.AddApplication();
            services.AddSwaggerGen();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseForwardedHeaders();
            }
            else
            {
                app.UseForwardedHeaders();
                ;
                app.UseHsts();
            }

            app.UseCors(
                builder => builder
                    .WithOrigins("https://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiveClinic.ClinicManager V1");
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            Log.Information(@"

                        ._    ._             _________ .____    .___ _______  .____________  
                        | |   |_|_  __ ____  \_   ___ \|    |   |   |\      \ |   \_   ___ \ 
                        | |   | \ \/ // __ \ /    \  \/|    |   |   |/   |   \|   /    \  \/ 
                        | |___| |\  /\  ___/ \     \___|    |___|   /    |    \   \     \____
                        |____ \_| \/  \___  > \______  /_______ \___\____|__  /___|\______  /
                             \/           \/        \/        \/           \/            \/

                                                             
            ");
            Log.Information(@"█ ██ ███ ████ █████ █████ ████ ███ ██ █");
            Log.Information($"Clinic Manager [Version {GetType().Assembly.GetName().Version}] started successfully");
        }

        private List<Assembly> GetAppAssemblies()
        {
            return new List<Assembly>
            {
                typeof(Startup).GetTypeInfo().Assembly,
                typeof(Client).GetTypeInfo().Assembly,
                typeof(ClientRepository).GetTypeInfo().Assembly
            };
        }
    }
}
