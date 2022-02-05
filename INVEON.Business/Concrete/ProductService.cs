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
        private readonly IUnitOfWork _uow;


        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
            _productRepository = _uow.GetRepository<Product>();
        }


        public void Add(ProductInsertViewModel product)
        {
            var entity = new Product
            {
                Id = 0,
                Barcode = product.Barcode,
                Name = product.Name,
                CreatedBy = product.CreatedBy,
                Description = product.Description,
                InStock = product.Instock,
                IsActive = true,
                Price = product.Price,
                Image = product.Image,
                CreatedDate = DateTime.Now
            };

            _productRepository.Insert(entity);
            _uow.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _productRepository.Find(id);
            entity.IsActive = false;
            _productRepository.Update(entity);
            _uow.SaveChanges();
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
            entity.InStock = model.Instock;
            if (model.Image != null)
            {
                entity.Image = model.Image;
            }
            entity.UpdatedBy = model.UpdatedBy;
            entity.UpdatedDate = DateTime.Now;

            _productRepository.Update(entity);
            _uow.SaveChanges();
        }


    }
}
