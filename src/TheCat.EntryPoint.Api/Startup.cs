using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Refit;
using System;
using System.Text.Json.Serialization;
using TheCat.Application.Clients;
using TheCat.Application.Configs;
using TheCat.EntryPoint.Api.Configs;
using Prometheus;

namespace TheCat.EntryPoint.Api
{
    public class Startup
    {
        public Startup(IConfiguration _configuration, IWebHostEnvironment webHostEnvironment)
        {
            configuration = _configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IConfiguration configuration { get; }
        public IWebHostEnvironment _webHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (_webHostEnvironment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("ConnectionString", "Data Source=.\\SQLEXPRESS;Initial Catalog=TheCat;User ID=rfcunha;Password=1234567");
                Environment.SetEnvironmentVariable("Banco", "Sql");
                Environment.SetEnvironmentVariable("Issuer", "ExmploIssuer");
                Environment.SetEnvironmentVariable("Seconds", "28800");
            }

            services.AddOptions();          

            services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(x => x.SerializerOptions.IncludeFields = true);

            services.Configure<UrlsConfigs>(configuration.GetSection("urlApis"));

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration(configuration);

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            services.AddRefitClient<ITheCatApi>()
                .ConfigureHttpClient((s, h) => {

                    var url = s.GetRequiredService<IOptions<UrlsConfigs>>().Value.TheCatApi;

                    h.BaseAddress = url;
                    h.Timeout = TimeSpan.FromMinutes(5);

                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheCat.Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheCat.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseHttpMetrics();
            app.UseMetricServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Realiza o Migration do banco de dados sem precisar executar command
            //if (configuration.GetSection("SqlConfiguration").GetSection("Migration").Value.Equals("True"))
            //{
            //    using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //    {
            //        using (var context = service.ServiceProvider.GetService<TheCatContext>())
            //        {
            //            context.Database.Migrate();
            //        }
            //    }
            //}
        }

    }
}
