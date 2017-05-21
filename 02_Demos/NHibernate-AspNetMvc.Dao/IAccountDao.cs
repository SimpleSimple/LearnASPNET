using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spring.Data.Core;
using System.Data;
namespace NHibernate_AspNetMvc.Dao
{
    public interface IAccountDao
    {
        void Create(string name, string userName);

        void Delete(string userName);
    }
    public class AccountDao : AdoDaoSupport, IAccountDao
    {
        public void Create(string name, string userName)
        {
            AdoTemplate.ExecuteNonQuery(CommandType.Text,
                String.Format("INSERT INTO AccountTable (UserName,    AccountName) VALUES ('{0}', '{1}')", userName, name));
        }

        public void Delete(string userName)
        {
            AdoTemplate.ExecuteNonQuery(CommandType.Text,
                String.Format("DELETE FROM AccountTable WHERE UserName = '{0}'", userName));
        }
    }
}
