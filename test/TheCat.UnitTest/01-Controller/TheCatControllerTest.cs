using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TheCat.Application.Interfaces;
using TheCat.Application.ViewModels.AnuncioTheCat;
using TheCat.Application.ViewModels.Breeds;
using TheCat.EntryPoint.Api.Controllers.V1;
using Xunit;

namespace TheCat.UnitTest.Controller
{

    public class TheCatControllerTest
    {
        private readonly Mock<IBreedsAppServices> _moqServiceBreeds;
        private readonly Mock<ILoggerAppServices> _moqServiceLogger;

        private TheCatController _controller;


        public TheCatControllerTest()
        {
            _moqServiceBreeds = new Mock<IBreedsAppServices>();
            _moqServiceLogger = new Mock<ILoggerAppServices>();

            _controller = new TheCatController(_moqServiceBreeds.Object, _moqServiceLogger.Object);
        }

        [Fact]
        public async Task GetAllBreed_WhenCalled_Should_Return_Ok()
        {
            _moqServiceBreeds.Setup(x => x.GetAllBreed()).ReturnsAsync(FillDataGetAllBreeds());

            var controllerResult = await _controller.GetAllBreed();

            var okResult = (ObjectResult)controllerResult;
            var okResultValue = okResult.Value as IEnumerable<BreedsViewModel>;

            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

            Assert.True(okResultValue is not null);
            Assert.True(okResultValue?.Any());
        }

        [Fact]
        public async Task GetBreed_WhenCalled_Should_Return_Ok()
        {
            _moqServiceBreeds.Setup(x => x.GetBreed(It.IsAny<string>())).ReturnsAsync(FillDataGetBreeds());

            var controllerResult = await _controller.GetBreed("Name1");

            var okResult = (ObjectResult)controllerResult;
            var okResultValue = okResult.Value as BreedsViewModel;

            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(okResultValue is not null);
        }


        private IEnumerable<BreedsViewModel> FillDataGetAllBreeds()
        {
            var list = new List<BreedsViewModel>
            {
                new BreedsViewModel
                {
                    description= "Description1",
                    id = "abcd",
                    name= "Name1",
                    origin = "BRA",
                    temperament = "temperament1",
                    BreedsImages = new List<BreedsImagesViewModel>()
                },
                new BreedsViewModel
                {
                    description= "Description2",
                    id = "abcd2",
                    name= "Name1",
                    origin = "BRA",
                    temperament = "temperament2",
                    BreedsImages = new List<BreedsImagesViewModel>()
                }
            };

            return list;
        }

        private BreedsViewModel FillDataGetBreeds()
        {
            var item = new BreedsViewModel
            {
                description = "Description1",
                id = "abcd",
                name = "Name1",
                origin = "BRA",
                temperament = "temperament1",
                BreedsImages = new List<BreedsImagesViewModel>()
            };

            return item;
        }
    }
}
