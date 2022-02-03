using INVEON.Core.Entities;
using System.Collections.Generic;

namespace INVEON.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
