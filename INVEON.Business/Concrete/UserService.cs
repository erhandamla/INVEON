using INVEON.Business.Abstract;
using INVEON.Core.Entities;
using INVEON.Data.Repository;
using INVEON.Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace INVEON.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork uow)
        {
            _userRepository = uow.GetRepository<User>();
        }

        public void Add(User entity)
        {
            _userRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            var entity = _userRepository.Find(id);
            _userRepository.Delete(entity);
        }

        public List<User> GetList()
        {
            return _userRepository.GetAll().ToList();
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }
    }
}
