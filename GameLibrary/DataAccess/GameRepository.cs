using GameLibrary.Data;
using Microsoft.Data.SqlClient;

namespace GameLibrary.DataAccess
{
    internal class GameRepository : IRepository<Game, int>
    {
        private readonly string _connectionString;

        public GameRepository() 
        {
            _connectionString = File.ReadAllText("connectionString.txt");
        }

        public async Task<int> Delete(Game item)
        {
            string sql = "@DELETE FROM [dbo].[Game] WHERE RawgId = @ID";
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", item.RawgId);

            int affectedRow = 0;
            try
            {
                connection.Open();
                affectedRow = await command.ExecuteNonQueryAsync();
                return affectedRow;
            } 
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }
        }

        public async Task<Game> Get(int key)
        {
            string sql = "@SELECT FROM [dbo].[Game] WHERE RawgId = @ID";
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", key);

            Game game = null;
            try
            {
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        game = new Game()
                        {
                            Name = reader["Name"].ToString(),
                            RawgId = (int)reader["RawgId"]
                        };
                    }
                }
                return game;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }
        }

        public Task<List<Game>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Game item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Game item)
        {
            throw new NotImplementedException();
        }
    }
}
