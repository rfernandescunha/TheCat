using TheCat.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace TheCat.EntryPoint.Api.Configs
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
