﻿using LiveClinic.ClinicManager.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.ClinicManager.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IClientService, ClientService>();
            return services;
        }
    }
}
