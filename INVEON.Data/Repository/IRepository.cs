using System.Linq;

namespace INVEON.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entityToDelete);
        TEntity Find(int id);
        IQueryable<TEntity> GetAll();

    }
}
