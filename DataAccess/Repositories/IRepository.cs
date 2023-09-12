using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        int Count();
    }
}
