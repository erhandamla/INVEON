using INVEON.Core.Entities;
using INVEON.Data.Repository;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace INVEON.Data.context
{
    public class INVEONContext : DbContext
    {
        private readonly INVEONContext _context;

        public INVEONContext() : base("name=dbINVEONEntities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public  DbSet<User> User { get; set; }
        public  DbSet<Product> Product { get; set; }
        public  DbSet<Stock> Stock { get; set; }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }
     
    }
}
