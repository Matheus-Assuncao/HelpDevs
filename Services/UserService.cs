using MySqlConnector;
using Microsoft.Extensions.Configuration;
using HelpDevs.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HelpDevs.Data
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                Console.WriteLine("Dentro do Add User");
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                Console.WriteLine("Conectado ao Banco");

                string query = "INSERT INTO usertb (userName,password) VALUES (@userName,@userPassword)";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", user.Name);
                cmd.Parameters.AddWithValue("@userPassword", user.Password);

                int result = await cmd.ExecuteNonQueryAsync();

                Console.WriteLine("Adicionado.");
                return result > 0; //Retorna valor bool se o resultado deu certo

            }

            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }

        }

        public async Task<bool> VerifyUser(User user)
        {
            try
            {
                //Abrindo conexao
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                //Configurado query (comando SLQ)
                string query = "SELECT COUNT(*) FROM usertb WHERE userName = @userName AND password = @password ";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", user.Name);
                cmd.Parameters.AddWithValue("@password", user.Password);

                var result = await cmd.ExecuteScalarAsync();
                int resultInt = Convert.ToInt32(result);

                if (resultInt == 1) return true;
                else return false;
            }

            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }
        
    }
}