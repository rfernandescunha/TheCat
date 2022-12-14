using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCat.Application.AutoMapper;
using TheCat.EntryPoint.Api;
using TheCat.Infra.Data;
using Xunit;

namespace TheCat.IntegrationTest
{
    public abstract class BaseIntegration : IDisposable
    {
        public TheCatContext apiContext { get; private set; }
        public HttpClient httpClient { get; private set; }
        public IMapper mapper { get; private set; }
        public string hostApi { get; set; }
        public HttpResponseMessage httpResponseMessage { get; set; }

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/v1/TheCat/";

            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>();

            var server = new TestServer(builder);

            apiContext = server.Host.Services.GetService(typeof(TheCatContext)) as TheCatContext;

            mapper = new AutoMapperFixture().GetMapper();

            httpClient = server.CreateClient();
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            apiContext.Dispose();
            httpClient.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public void Dispose() { }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new DomainToViewModelMappingProfile());
                x.AddProfile(new ViewModelToDomainMappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
