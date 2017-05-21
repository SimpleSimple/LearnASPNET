
using System;
using System.Collections.Generic;

using System.Data;
using NHibernate_AspNetMvc.Dao;
using Spring.Transaction.Interceptor;
namespace NHibernate_AspNetMvc.Service
{
    public interface IUserService
    {
        void SaveData(string name, int age, string accountName);

        void DeleteData(string name);

        DataSet Get(string name);
    }

    public class UserService : IUserService
    {
        public IUserDao UserDao { get; set; }

        public IAccountDao AccountDao { get; set; }

        [Transaction]
        public void SaveData(string name, int age, string accountName)
        {
            UserDao.Create(name, age);
            AccountDao.Create(accountName, name);
        }

        [Transaction]
        public void DeleteData(string name)
        {
            UserDao.Delete(name);
            AccountDao.Delete(name);
        }

        [Transaction(ReadOnly = true)]
        public DataSet Get(string name)
        {
            return UserDao.Get(name);
        }
    }
}
