using TheCat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Domain.Interfaces.IRepository
{
    public interface IBreedsRepository : IBaseRepository<Breeds>
    {
        Task<bool> InsertRange(List<Breeds> list);
    }
}
