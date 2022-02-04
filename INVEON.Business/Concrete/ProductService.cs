using INVEON.Business.Abstract;
using INVEON.Core.Entities;
using INVEON.Data.Repository;
using INVEON.Data.UnitOfWork;
using INVEON.Dtos.ViewModels;
using System;
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
            _productRepository.Insert(entity);
        }

        public void Delete(int id)
        {
            var entity = _productRepository.Find(id);
            _productRepository.Delete(entity);
        }

        public Product Find(int id)
        {
            return _productRepository.Find(id);
        }

        public List<Product> GetList()
        {
            return _productRepository.GetAll().ToList(); ;
        }

        public void Update(ProductUpdateViewModel model)
        {
            var entity = _productRepository.Find(model.Id);
            entity.Barcode = model.Barcode;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Image = model.Image;
            entity.UpdatedBy = model.UpdatedBy;
            entity.UpdatedDate = DateTime.Now;

            _productRepository.Update(entity);
        }
    }
}
