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
    public class BreedsImagesServices : IBreedsImagesServices
    {
        private readonly IBreedsImagesRepository _BreedsImagesRepository;
        private readonly NotificationContext _notificationContext;

        public BreedsImagesServices(IBreedsImagesRepository BreedsImagesRepository)
        {
            _BreedsImagesRepository = BreedsImagesRepository;
            _notificationContext = new NotificationContext();
        }
        public async Task<bool> Delete(string Id)
        {
            return await _BreedsImagesRepository.Delete(Id);
        }

        public async Task<BreedsImages> Find(string Id)
        {
            return await _BreedsImagesRepository.Find(Id);
        }

        public async Task<IEnumerable<BreedsImages>> Find(Expression<Func<BreedsImages, bool>> predicate = null)
        {
            return await _BreedsImagesRepository.Find(predicate);
        }

        public async Task<BreedsImages> Insert(BreedsImages entity)
        {
            entity.Validate(entity, new BreedsImagesInsert());

            if(entity.Invalid)            
                return entity;            

            return await _BreedsImagesRepository.Insert(entity);
        }

        public async Task<bool> InsertRange(List<BreedsImages> list)
        {
            foreach (var entity in list)
            {
                entity.Validate(entity, new BreedsImagesInsert());
            }

            await _BreedsImagesRepository.InsertRange(list);

            return true;
        }

        public async Task<BreedsImages> Update(BreedsImages entity)
        {
            entity.Validate(entity, new BreedsImagesUpdate());

            return await _BreedsImagesRepository.Update(entity);
        }
    }
}
