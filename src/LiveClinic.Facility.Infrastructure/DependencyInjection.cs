using System.Collections.Generic;
using System.Reflection;
using LiveClinic.ClinicManager.Core.Domain.Clients;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using LiveClinic.ClinicManager.Core.Domain.Staff;
using LiveClinic.ClinicManager.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.ClinicManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, List<Assembly> assemblies)
        {
            services.AddEventPublisher(assemblies);
            services.AddMongoDb(configuration);
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }
    }
}
