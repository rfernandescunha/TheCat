using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheCat.Application.ViewModels.AnuncioTheCat;
using TheCat.Application.ViewModels.Breeds;

namespace TheCat.Application.Clients
{
    public interface ITheCatApi
    {
        [Get("/v1/breeds?api_key=live_v0PHO7GKgDfHSx3KjTmfSGaljx3xXwPgl4KPSgqDumM7GmRsFtVWAHxcNURnB2jb")]
        Task<List<BreedsViewModel>> GetAllBreeds();

        [Get("/v1/images/search?limit=100&breed_ids={breeds_id}&api_key=live_v0PHO7GKgDfHSx3KjTmfSGaljx3xXwPgl4KPSgqDumM7GmRsFtVWAHxcNURnB2jb")]
        Task<List<BreedsImagesViewModel>> GetAllBreedsImages(string breeds_id);
    }
}
