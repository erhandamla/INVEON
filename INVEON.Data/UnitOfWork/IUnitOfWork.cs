using INVEON.Data.Repository;
using System;

namespace INVEON.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        /// <summary>
        /// veritabani degisiklikleri kaydet.
        /// </summary>
        int SaveChanges();

    }
}
