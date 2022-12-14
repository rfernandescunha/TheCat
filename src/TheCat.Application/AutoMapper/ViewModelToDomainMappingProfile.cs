
using AutoMapper;
using TheCat.Application.ViewModels.AnuncioTheCat;
using TheCat.Application.ViewModels.Breeds;
using TheCat.Application.ViewModels.Logger;
using TheCat.Domain.Entities;

namespace TheCat.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BreedsViewModel, Breeds>();

            CreateMap<BreedsImagesViewModel, BreedsImages>().ForMember(x => x.idbreedsNavigation, opt => opt.Ignore());

            CreateMap<LoggerRequestViewModel, LoggerRequest>();
        }
    }
}
