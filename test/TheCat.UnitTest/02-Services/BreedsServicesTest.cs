using Moq;
using System.Linq.Expressions;
using TheCat.Domain.Entities;
using TheCat.Domain.Interfaces.IRepository;
using TheCat.Domain.Services;
using Xunit;

namespace TheCat.UnitTest.Services
{
    public  class BreedsServicesTest
    {
        private readonly Mock<IBreedsRepository> _mockBreedsRepository;

        private readonly BreedsServices _breedsServices;

        public BreedsServicesTest()
        {
            _mockBreedsRepository= new Mock<IBreedsRepository>();

            _breedsServices = new BreedsServices(_mockBreedsRepository.Object);
        }

        [Fact]
        public async Task Find_WhenCalled_Should_Return_Ok()
        {
            _mockBreedsRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Breeds, bool>>>())).Returns(FillDataGetAllBreeds());

            var result = await _breedsServices.Find();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Breeds>>(result);
            Assert.True(result.Any());
        }


        private Task<IEnumerable<Breeds>> FillDataGetAllBreeds()
        {
            var list = new List<Breeds>
            {
                new Breeds
                {
                    description= "Description1",
                    id = "abcd",
                    name= "Name1",
                    origin = "BRA",
                    temperament = "temperament1",
                    BreedsImages = new List<BreedsImages>()
                },
                new Breeds
                {
                    description= "Description2",
                    id = "abcd2",
                    name= "Name1",
                    origin = "BRA",
                    temperament = "temperament2",
                    BreedsImages = new List<BreedsImages>()
                }
            };

            return Task.FromResult((IEnumerable<Breeds>)list);
        }

        private Breeds FillDataGetBreeds()
        {
            var item = new Breeds
            {
                description = "Description1",
                id = "abcd",
                name = "Name1",
                origin = "BRA",
                temperament = "temperament1",
                BreedsImages = new List<BreedsImages>()
            };

            return item;
        }

    }
}
