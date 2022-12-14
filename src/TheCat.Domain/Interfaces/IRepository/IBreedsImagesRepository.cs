using TheCat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Domain.Interfaces.IRepository
{
    public interface IBreedsImagesRepository : IBaseRepository<BreedsImages>
    {
        Task<bool> InsertRange(List<BreedsImages> list);
    }
}
