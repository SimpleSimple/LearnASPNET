using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        IQueryable<User> GetUsers();
        IList<User> GetUsers(Byte status);
        User GetUser(string name);
        User GetUser(string name, string password);

        void RemoveAll();
    }
}
