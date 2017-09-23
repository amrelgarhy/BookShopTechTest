using BookShop.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public static ICollection<TEntity> data = new List<TEntity>();

        public IQueryable<TEntity> Items => throw new NotImplementedException();

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.Id = data.Count > 0 ? data.Last().Id + 1 : 1;

            data.Add(entity);

            return entity;
        }

        public bool Delete(long id)
        {
            var foundEntity = Get(id);
            if (foundEntity == null)
            {
                return false;
            }
            return data.Remove(foundEntity);
        }

        public TEntity Get(long id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<TEntity> GetAll()
        {
            return data;
        }

        public TEntity Update(TEntity entity)
        {
            var foundEntity = Get(entity.Id);

            foundEntity = entity;

            return foundEntity;
        }
    }
}
