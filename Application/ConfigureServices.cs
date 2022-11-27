using Application.Services;
using Application.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ConfigureServices
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<EntityValidation>();
            serviceCollection.AddScoped<MovieManager>();
            serviceCollection.AddScoped<ProjectionManager>();
            serviceCollection.AddScoped<SaloonManager>();
        }
    }
}
