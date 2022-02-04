using INVEON.Core.Entities;
using INVEON.Dtos.ViewModels;
using System.Collections.Generic;

namespace INVEON.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        void Add(Product product);
        void Update(ProductUpdateViewModel product);
        void Delete(int id);
        Product Find(int id);
    }
}
