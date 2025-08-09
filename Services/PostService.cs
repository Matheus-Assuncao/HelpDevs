using Microsoft.AspNetCore.Connections;
using HelpDevs.Models;
using MySqlConnector;

namespace HelpDevs.Services
{
    public class PostService
    {
        private readonly string _connectionString;

        public PostService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> CreatePost(Post post)
        {

            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync(); // Abrir conexao assincrona

                string query = "INSERT INTO Posts (user,text,datePosted) VALUES (@user,@text,@datePosted)";
                var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user", post._User);
                cmd.Parameters.AddWithValue("@text", post.Text);
                cmd.Parameters.AddWithValue("@datePosted", post.DatePosted);

                int result = await cmd.ExecuteNonQueryAsync();

                return result > 0;
            }
            catch (Exception err)
            {
                Console.WriteLine("Erro no PostService");
                Console.WriteLine(err);
                return false;
            }

        }

    }
}