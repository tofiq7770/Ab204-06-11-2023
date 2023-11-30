using Microsoft.Data.SqlClient;
using System.Data;

namespace Ab104.Services
{
    internal class SQL
    {
        private const string _connectionString = "server=DESKTOP-SOBUBL4;database=Task6november;trusted_connection=true;integrated security=true;encrypt=false";
        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public static int ExecuteCommand(string command)
        {
            int result = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(command);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public static DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
                adapter.Fill(table);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return table;
        }
    }
}
