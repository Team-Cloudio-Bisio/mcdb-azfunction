using System.Data.SqlClient;

namespace minecraftsaas.DB {
    public class DBConnectionUtils {

        private SqlConnection connection;

        public DBConnectionUtils(string connectionString) {
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection() {
            connection.Open();
            return connection;
        }

        public void CloseConnection() {
            connection.Close();
        }
    
    }
}