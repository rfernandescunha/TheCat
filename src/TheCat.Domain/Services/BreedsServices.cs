using TheCat.Domain.Entities;
using TheCat.Domain.Validation;
using TheCat.Domain.Interfaces.IRepository;
using TheCat.Domain.Interfaces.IServices;
using TheCat.Domain.Notifications;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheCat.Domain.Validation.AnuncioTheCat;

namespace TheCat.Domain.Services
{
    public class BreedsServices : IBreedsServices
    {
        private readonly IBreedsRepository _BreedsRepository;
        private readonly NotificationContext _notificationContext;

        public BreedsServices(IBreedsRepository BreedsRepository)
        {
            _BreedsRepository = BreedsRepository;
            _notificationContext = new NotificationContext();
        }
        public async Task<bool> Delete(string Id)
        {
            return await _BreedsRepository.Delete(Id);
        }

        public async Task<Breeds> Find(string Id)
        {
            return await _BreedsRepository.Find(Id);
        }

        public async Task<IEnumerable<Breeds>> Find(Expression<Func<Breeds, bool>> predicate = null)
        {
            return await _BreedsRepository.Find(predicate);
        }

        public async Task<Breeds> Insert(Breeds entity)
        {
            entity.Validate(entity, new BreedsInsert());

            if(entity.Invalid)            
                return entity;            

            return await _BreedsRepository.Insert(entity);
        }

        public async Task<bool> InsertRange(List<Breeds> list)
        {
            foreach (var entity in list)
            {
                entity.Validate(entity, new BreedsInsert());
            }

            await _BreedsRepository.InsertRange(list);

            return true;
        }

        public async Task<Breeds> Update(Breeds entity)
        {
            entity.Validate(entity, new BreedsUpdate());

            return await _BreedsRepository.Update(entity);
        }
    }
}
