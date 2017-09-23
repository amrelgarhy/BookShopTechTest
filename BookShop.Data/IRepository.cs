using BookShop.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Add(TEntity entity);
        bool Delete(long id);
        TEntity Get(long id);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> Items { get; }
        ICollection<TEntity> GetAll();
    }
}
