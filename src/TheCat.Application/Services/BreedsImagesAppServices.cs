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
using TheCat.Domain.Services;
using TheCat.Application.Clients;

namespace TheCat.Application.Services
{
    public class BreedsImagesAppServices: IBreedsImagesAppServices
    {
        private readonly IMapper _mapper;
        private readonly IBreedsImagesServices _breedsImagesServices;
        private readonly ITheCatApi _clientsTheCatApi;

        public BreedsImagesAppServices(
                                                IBreedsImagesServices breedsImagesServices,
                                                IMapper mapper,
                                                ITheCatApi clientsTheCatApi
            )
        {
            _mapper = mapper;
            _breedsImagesServices = breedsImagesServices;
            _clientsTheCatApi = clientsTheCatApi;
        }

        public async Task<bool> Delete(string Id)
        {
            return await _breedsImagesServices.Delete(Id);
        }

        public async Task<IEnumerable<BreedsImagesViewModel>> Find(Expression<Func<BreedsImages, bool>> predicate = null)
        {
            var retorno = await _breedsImagesServices.Find(predicate);

            return _mapper.Map<IEnumerable<BreedsImagesViewModel>>(retorno);
        }

        public async Task<BreedsImagesViewModel> Find(string Id)
        {          

            var item =  await _breedsImagesServices.Find(Id);

            return _mapper.Map<BreedsImagesViewModel>(item);
        }

        public async Task<BreedsImagesViewModel> Insert(BreedsImagesViewModel Objeto)
        {
            var entrada = _mapper.Map<BreedsImages>(Objeto);

            var retorno = await _breedsImagesServices.Insert(entrada);

            return  _mapper.Map<BreedsImagesViewModel>(retorno);
        }

        public async Task<bool> InsertRange(List<BreedsImagesViewModel> list)
        {
            var entrada = _mapper.Map<List<BreedsImages>>(list);

            var retorno = await _breedsImagesServices.InsertRange(entrada);

            return retorno;
        }

        public async Task<BreedsImagesViewModel> Update(BreedsImagesViewModel Objeto)
        {
            var entrada = _mapper.Map<BreedsImages>(Objeto);

            var retorno = await _breedsImagesServices.Update(entrada);

            return _mapper.Map<BreedsImagesViewModel>(retorno);
        }

        private async Task<IEnumerable<BreedsImagesViewModel>> GetAllBreedsImages(string idBreed)
        {
            var result = await _clientsTheCatApi.GetAllBreedsImages(idBreed);

            return result;
        }

    }
}
