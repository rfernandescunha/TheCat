using AutoMapper;
using TheCat.Application.Interfaces;
using TheCat.Application.ViewModels;
using TheCat.Domain.Entities;
using TheCat.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheCat.Application.ViewModels.AnuncioTheCat;
using TheCat.Application.ViewModels.Breeds;
using System.Linq;
using System.Transactions;
using TheCat.Application.Clients;

namespace TheCat.Application.Services
{
    public class BreedsAppServices:IBreedsAppServices
    {
        private readonly IMapper _mapper;
        private readonly IBreedsServices _breedsServices;
        private readonly IBreedsImagesServices _breedsImagesServices;
        private readonly ITheCatApi _clientsTheCatApi;

        public BreedsAppServices(
                                                IBreedsServices breedsServices,
                                                IBreedsImagesServices breedsImagesServices,
                                                IMapper mapper,
                                                ITheCatApi clientsTheCatApi
            )
        {
            _mapper = mapper;
            _breedsServices = breedsServices;
            _breedsImagesServices = breedsImagesServices;
            _clientsTheCatApi = clientsTheCatApi;
        }


        public async Task<BreedsViewModel> GetBreed(string breed)
        {          

            var item =  await Find(x=> x.name == breed);

            return item.FirstOrDefault();
        }

        public async Task<IEnumerable<BreedsViewModel>> GetAllBreed()
        {

            var item = await Find();

            var list = _mapper.Map<IEnumerable<BreedsViewModel>>(item);

            return list;
        }

        public async Task<IEnumerable<BreedsViewModel>> GetBreedForOrigin(string origin)
        {

            var item = await Find(x => x.origin == origin);

            return item;
        }

        public async Task<IEnumerable<BreedsViewModel>> GetBreedForTemperament(string temperament)
        {

            var item = await Find(x => x.temperament.Contains(temperament));

            return item;
        }

        private async Task<IEnumerable<BreedsViewModel>> Find(Expression<Func<Breeds, bool>> predicate = null)
        {
            var retorno = await _breedsServices.Find(predicate);

            return _mapper.Map<IEnumerable<BreedsViewModel>>(retorno);
        }

        public async Task<bool> InsertRange(List<BreedsViewModel> list)
        {
            var entrada = _mapper.Map<List<Breeds>>(list);

            var retorno = await _breedsServices.InsertRange(entrada);

            return retorno;
        }


        private async Task<IEnumerable<BreedsViewModel>> GetAllBreeds()
        {
            var result = await _clientsTheCatApi.GetAllBreeds();

            return result;
        }

        private async Task<IEnumerable<BreedsImagesViewModel>> GetAllBreedsImages(string idBreeds)
        {
            var result = await _clientsTheCatApi.GetAllBreedsImages(idBreeds);

            return result;
        }

        public async Task<bool> ImportAllBreeds()
        {

            var list = await GetAllBreeds();

            await InsertRange(list.ToList());

            foreach (var item in list)
            {
                var listImages = GetAllBreedsImages(item.id);

                listImages.Result.ToList().ForEach(c => c.idbreeds = item.id);

                await ImportAllBreedsImages(listImages.Result.ToList());
            }

            return true;
        }


        private async Task ImportAllBreedsImages(List<BreedsImagesViewModel> listBreedsImages)
        {
            var entrada = _mapper.Map<List<BreedsImages>>(listBreedsImages);

            await _breedsImagesServices.InsertRange(entrada);
        }

    }
}
