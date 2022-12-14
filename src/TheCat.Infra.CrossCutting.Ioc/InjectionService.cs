using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TheCat.Application.Interfaces;
using TheCat.Application.Services;
using TheCat.Domain.Interfaces.IRepository;
using TheCat.Domain.Interfaces.IServices;
using TheCat.Domain.Services;

namespace TheCat.Infra.CrossCutting.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBreedsAppServices, BreedsAppServices>();
            serviceCollection.AddScoped<IBreedsImagesAppServices, BreedsImagesAppServices>();
            serviceCollection.AddScoped<ILoggerAppServices, LoggerAppServices>();

            serviceCollection.AddScoped<IBreedsServices, BreedsServices>();
            serviceCollection.AddScoped<IBreedsImagesServices, BreedsImagesServices>();
            serviceCollection.AddScoped<ILoggerServices, LoggerServices>();
        }
    }
}
