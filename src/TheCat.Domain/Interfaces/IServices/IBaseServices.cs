using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Domain.Interfaces.IServices
{
    public interface IBaseServicesBase<T> where T : class
    {
        Task<T> Find(string Id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate = null);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(string Id);
    }
}
