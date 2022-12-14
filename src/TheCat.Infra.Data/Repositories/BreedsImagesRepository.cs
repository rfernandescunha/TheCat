using TheCat.Domain.Entities;
using TheCat.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TheCat.Infra.Data.Repositories
{
    public class BreedsImagesRepository : BaseRepository<BreedsImages>, IBreedsImagesRepository
    {
        private readonly TheCatContext _context;
        public BreedsImagesRepository(TheCatContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task<bool> InsertRange(List<BreedsImages> list)
        {
            await _context.Set<BreedsImages>().AddRangeAsync(list);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
