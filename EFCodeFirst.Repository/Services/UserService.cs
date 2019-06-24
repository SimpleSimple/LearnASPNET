using EFCodeFirst.Repository.Model;
using EFCodeFirst.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }


        public int AddUser(User user)
        {
            return repository.AddUser(user);
        }
        public User GetUser(string name)
        {
            return repository.GetUser(name);
        }
        public User GetUser(string name, string password)
        {
            return repository.GetUser(name, password);
        }
        public IList<User> GetUsers(Byte status)
        {
            return repository.GetUsers(status);
        }
        public IList<User> GetUsers()
        {
            return repository.GetUsers().ToList();
        }

        public void RemoveAll()
        {
            repository.RemoveAll();
        }


    }
}
