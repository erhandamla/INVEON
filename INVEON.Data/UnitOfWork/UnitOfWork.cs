using INVEON.Data.context;
using INVEON.Data.Repository;
using System;

namespace INVEON.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly INVEONContext _context;
        private bool disposed = false;
        public UnitOfWork(INVEONContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }

        public int SaveChanges()
        {
            var affectedRow = 0;
            affectedRow = _context.SaveChanges();
            return affectedRow;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
