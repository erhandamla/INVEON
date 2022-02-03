using INVEON.Business.Abstract;
using INVEON.Core.Entities;
using INVEON.Data.Repository;
using INVEON.Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace INVEON.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IUnitOfWork uow)
        {
            _productRepository = uow.GetRepository<Product>();
        }

        public void Add(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            var entity = _productRepository.Find(id);
            _productRepository.Delete(entity);
        }

        public List<Product> GetList()
        {
            return _productRepository.GetAll().ToList(); ;
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
