using INVEON.Core.Entities;
using System.Collections.Generic;

namespace INVEON.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
