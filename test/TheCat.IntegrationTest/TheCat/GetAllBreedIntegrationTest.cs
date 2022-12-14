using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheCat.Application.ViewModels.AnuncioTheCat;
using Xunit;

namespace TheCat.IntegrationTest.TheCat
{
    public class GetAllBreedIntegrationTest : BaseIntegration
    {
        [Fact]
        public async Task GetAllBreed_WhenCalled_Should_Return_Ok()
        {

            var response = await httpClient.GetAsync($"{hostApi}GetAllBreed");


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();

            var retorno = JsonConvert.DeserializeObject<IEnumerable<BreedsViewModel>>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(retorno);
            Assert.True(retorno.Any());
        }
    }
}
