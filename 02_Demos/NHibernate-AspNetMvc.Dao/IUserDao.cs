
using System;
using System.Collections.Generic;

using System.Data;
using Spring.Data.Core;
namespace NHibernate_AspNetMvc.Dao
{
    public interface IUserDao
    {
        void Create(string name, int age);

        void Delete(string name);

        DataSet Get(string name);
    }
    public class UserDao : AdoDaoSupport, IUserDao
    {
        public void Create(string name, int age)
        {
            AdoTemplate.ExecuteNonQuery(CommandType.Text,
                string.Format("INSERT INTO UserTable (UserName,    UserAge) VALUES ('{0}', {1})", name, age));
        }

        public void Delete(string name)
        {
            AdoTemplate.ExecuteNonQuery(CommandType.Text,
                string.Format("DELETE FROM UserTable WHERE UserName = '{0}'", name));
        }

        public DataSet Get(string name)
        {
            return AdoTemplate.DataSetCreate(CommandType.Text,
                string.Format("SELECT * FROM UserTable WHERE UserName = '{0}'", name));
        }
    }
}
