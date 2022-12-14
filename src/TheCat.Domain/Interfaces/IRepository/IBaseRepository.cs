using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Domain.Interfaces.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Insert(T Objeto);
        Task<T> Update(T Objeto);
        Task<bool> Delete(string Id);
        Task<T> Find(string Id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate = null);
    }

}
