using Bussiness.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(User entity)
        {
           
                _userRepository.Create(entity);
            
        }

        public void Delete(User entity)
        {
           _userRepository.Delete(entity);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
           return _userRepository.GetById(id);
        }

        public User GetByUsername(string username)
        {
           return _userRepository.GetByUsername(username);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }

        public bool Validaton(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
