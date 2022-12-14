using AutoMapper;
using TheCat.Domain.Entities;
using TheCat.Application.ViewModels.AnuncioTheCat;
using TheCat.Application.ViewModels.Breeds;
using TheCat.Application.ViewModels.Logger;

namespace TheCat.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Breeds, BreedsViewModel>();
            CreateMap<BreedsImages, BreedsImagesViewModel>();

            CreateMap<LoggerRequest, LoggerRequestViewModel>();
        }
    }
}
