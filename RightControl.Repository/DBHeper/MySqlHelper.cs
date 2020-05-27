using MySql.Data.MySqlClient;
using System.Data.Common;

namespace RightControl.Repository
{
    public class MySqlHelper
    {
        public static string mysqlconnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlconn"].ConnectionString;

        public static DbConnection GetConnection()
        {
            var connection = new MySqlConnection(mysqlconnectionString);
            connection.Open();
            return connection;
        }
    }
}
