using System;
using System.Data.SqlClient;

namespace MyERP.DataAccess
{
    public class SingleConnection
    {
        private SingleConnection() { }

        private static SingleConnection _singleConnection = null;

        private String _connString = null;

        public static string ConnString
        {
            get
            {
                if (_singleConnection == null)
                {
                    _singleConnection = new SingleConnection { _connString = SingleConnection.Connect() };
                    return _singleConnection._connString;
                }
                else
                    return _singleConnection._connString;
            }
        }

        private static string Connect()
        {
            //Build an SQL connection string
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = Environment.GetEnvironmentVariable("DATABASE_SERVER")??"localhost",    // Server name
                InitialCatalog = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? "myerp",    // Database
                UserID = Environment.GetEnvironmentVariable("DATABASE_USER")??"sa",                 // Username
                Password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "pass@word1", // Password
                MultipleActiveResultSets = (Environment.GetEnvironmentVariable("MARS")?.ToLower() ?? "false") == "true" ? true : false,
            };

            return sqlString.ToString();

            //Build an Entity Framework connection string
            //EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            //{
            //    Provider = "System.Data.SqlClient",
            //    Metadata = "res://*/testModel.csdl|res://*/testModel.ssdl|res://*/testModel.msl",
            //    ProviderConnectionString = sqlString.ToString()
            //};
            //return entityString.ConnectionString;

        }

    }


}
