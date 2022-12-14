using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheCat.Application.ViewModels.AnuncioTheCat;
using Xunit;

namespace TheCat.IntegrationTest.TheCat
{
    public class GetBreedIntegrationTest : BaseIntegration
    {
        [Theory]
        [InlineData("American Bobtail")]
        public async Task GetBreed_WhenCalled_Should_Return_Ok(string breed)
        {

            var response = await httpClient.GetAsync($"{hostApi}GetBreed/{breed} ");


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            
            var retorno = JsonConvert.DeserializeObject<BreedsViewModel>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(retorno);
            Assert.True(retorno.name == breed);
        }
    }
}
