using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Services
{
    public interface IUserService
    {
        int AddUser(User user);
        //void BatchAddUser(IList<User> list);
        User GetUser(string name);
        User GetUser(string name, string password);
        IList<User> GetUsers(Byte status);
        IList<User> GetUsers();
        void RemoveAll();


        //void AddUser(User user, out ValidationStateDictionary validationState, out User newUser);
        //void EditUser(User user, out ValidationStateDictionary validationState);
        //void EnsureAnonymousUser(Language languageDefault);
        //bool VerifyAccess(string name, Area area);
        //bool VerifyAccess(string name, Page page);
    }
}
