using HelpDevs.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

class UserSQL
{   
    // Atributo com a string de conexao
    private readonly string _stringDeConexao;

    //Método construtor
    public UserSQL(string conexao)
    {
        _stringDeConexao = conexao;
    }

    //Metodo para cadastrar uma pessoa
    public void Cadastrar(string name, string password)
    {
        string sql = "INSERT INTO USERTB(name,password) values(@name,@password)";

        using var conexao = new MySqlConnection(_stringDeConexao);
        using var comando = new MySqlCommand(sql, conexao);
        {
            // Especificar parâmetros SQL
            comando.Parameters.AddWithValue("@name",name);
            comando.Parameters.AddWithValue("@password",password);

            //Executar SQL
            try{
                conexao.Open();
                comando.ExecuteNonQuery();
                Console.WriteLine("Cadastro Efetuado");

            }catch(Exception e){
                Console.WriteLine(e);

            }
        }
    }

    //Método para verificar se o User existe
    public bool VerificaUser(string name, string password){
        using var conexao = new MySqlConnection(_stringDeConexao);
        
        //arrumando SQL
        string sql = "SELECT COUNT(*) FROM usertb WHERE NAME = @name AND PASSWORD = @password";
        using var comando = new MySqlCommand(sql, conexao);

        comando.Parameters.AddWithValue("@name",name);
        comando.Parameters.AddWithValue("@password",password);

        //executar SQL
        try{
            conexao.Open();
            var result = Convert.ToInt32(comando.ExecuteScalar());
            return result>0;
        }catch(Exception e){
            Console.WriteLine(e);
            return false;
        }finally{
            conexao.Close();
        }

    }
}