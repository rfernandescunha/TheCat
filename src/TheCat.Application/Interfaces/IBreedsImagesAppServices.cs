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
    public interface IBreedsImagesAppServices //: IBaseAppServices<Product>
    {
        Task<BreedsImagesViewModel> Insert(BreedsImagesViewModel item);

        Task<bool> InsertRange(List<BreedsImagesViewModel> list);
        Task<BreedsImagesViewModel> Update(BreedsImagesViewModel item);
        Task<bool> Delete(string Id);
        Task<BreedsImagesViewModel> Find(string Id);
        Task<IEnumerable<BreedsImagesViewModel>> Find(Expression<Func<BreedsImages, bool>> predicate = null);

    }
}
