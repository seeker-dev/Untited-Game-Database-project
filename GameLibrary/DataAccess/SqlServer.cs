using Microsoft.Data.SqlClient;

namespace GameLibrary.Database
{
    internal class SqlServer
    {
        private readonly string _connectionString;

        public SqlServer()
        {
            _connectionString = File.ReadAllText("connectionString.txt");
        }

        public async Task ExecuteNonQueryStatment(string sql)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            await command.ExecuteNonQueryAsync();
        }

        public async Task ExecuteQueryStatment(string sql)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            
            if (!reader.HasRows) return;
        }
    }
}
