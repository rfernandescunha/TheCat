using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Application.Interfaces
{
    public interface IBaseAppServices<T> where T : class
    {
        Task<T> Insert(T Objeto);
        Task<T> Update(T Objeto);
        Task<bool> Delete(Guid Id);
        Task<T> Find(Guid Id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate = null);
    }
}
