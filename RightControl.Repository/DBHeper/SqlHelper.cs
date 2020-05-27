using System.Collections.Concurrent;
using System.Configuration;
using System.Data.SqlClient;

namespace RightControl.Repository
{
    public class SqlHelper
    {
       
        private static string _connectionString  = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private static ConcurrentDictionary<int, SqlConnection> dicConnect = new ConcurrentDictionary<int, SqlConnection>();


    }
}
