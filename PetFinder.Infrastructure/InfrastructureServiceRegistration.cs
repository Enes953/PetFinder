using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Abstractions.Storage;
using PetFinder.Infrastructure.Services.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IStorageService, StorageService>();
            return services;

        }
        public static IServiceCollection AddStorage<T>(this IServiceCollection services, IConfiguration configuration) where T : Storage, IStorage
        {

            services.AddScoped<IStorage, T>();
            return services;

        }
    }
}

