using TheCat.Domain.Entities;
using TheCat.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace TheCat.Infra.Data.Repositories
{
    public class BreedsRepository : BaseRepository<Breeds>, IBreedsRepository
    {
        private readonly TheCatContext _context;
        public BreedsRepository(TheCatContext repositoryContext) : base(repositoryContext)
        {

            _context = repositoryContext;
        }

        public async Task<bool> InsertRange(List<Breeds> list)
        {
            await _context.Set<Breeds>().AddRangeAsync(list);
            await _context.SaveChangesAsync();

            return true;
        }

        public override async Task<IEnumerable<Breeds>> Find(Expression<Func<Breeds, bool>> predicate = null)
        {

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.LazyLoadingEnabled = false;

            if (predicate != null)
            {
                 IQueryable<Breeds> resut = _context.Set<Breeds>().Where(predicate).Include(x => x.BreedsImages).AsNoTracking();

                return resut;
            }
            else
            {
                IQueryable<Breeds> resut = _context.Set<Breeds>().Include(x => x.BreedsImages).AsNoTracking();

                return resut;
            }

        }
    }
}
