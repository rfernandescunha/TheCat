using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TheCat.Domain.Interfaces.IRepository;
using TheCat.Infra.Data;
using TheCat.Infra.Data.Repositories;

namespace TheCat.Infra.CrossCutting.Ioc
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<IBreedsRepository, BreedsRepository>();
            serviceCollection.AddScoped<IBreedsImagesRepository, BreedsImagesRepository>();


            //Pega a Conexao do arquivo lauch.json
            serviceCollection.AddDbContext<TheCatContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));

            
        }
    }
}
