using TheCat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Domain.Interfaces.IServices
{
    public interface IBreedsServices : IBaseServicesBase<Breeds> 
    {
        Task<bool> InsertRange(List<Breeds> list);
    }
}
