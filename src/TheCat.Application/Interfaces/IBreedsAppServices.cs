using TheCat.Application.ViewModels;
using TheCat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheCat.Application.ViewModels.AnuncioTheCat;
using TheCat.Application.ViewModels.Breeds;

namespace TheCat.Application.Interfaces
{
    public interface IBreedsAppServices //: IBaseAppServices<Product>
    {
        //Task<BreedsViewModel> Insert(BreedsViewModel item);

        Task<bool> InsertRange(List<BreedsViewModel> list);
        //Task<BreedsViewModel> Update(BreedsViewModel item);
        //Task<bool> Delete(string Id);
        Task<IEnumerable<BreedsViewModel>> GetAllBreed();
        Task<BreedsViewModel> GetBreed(string Id);
        Task<IEnumerable<BreedsViewModel>> GetBreedForOrigin(string origin);
        Task<IEnumerable<BreedsViewModel>> GetBreedForTemperament(string temperament);


        Task<bool> ImportAllBreeds();
    }
}
