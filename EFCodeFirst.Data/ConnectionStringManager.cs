using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.EntityClient;
namespace EFCodeFirst.Data
{
    public static class ConnectionStringManager
    {
        public static string ConnectionString = GetConnection();

        private static string GetConnection()
        {
            string providerName = "System.Data.SqlClient";

            var sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = System.Configuration.ConfigurationManager.AppSettings["Data Source"];
            sqlBuilder.InitialCatalog = System.Configuration.ConfigurationManager.AppSettings["Initial Catalog"];
            sqlBuilder.IntegratedSecurity = true;

            string providerString = sqlBuilder.ToString();

            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            entityBuilder.Provider = providerName;
            entityBuilder.ProviderConnectionString = providerString;
            return entityBuilder.ToString();
        }
    }
}
