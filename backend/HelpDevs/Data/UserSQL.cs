using HelpDevs.Data;
using MySql.Data.MySqlClient;

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
    public void Cadastrar(string nome, string password)
    {
        string sql = "INSERT INTO USERTB(name,password) values(@name,@password)";

        using var conexao = new MySqlConnection(_stringDeConexao);
        using var comando = new MySqlCommand(sql, conexao);
        {
            // Especificar parâmetros SQL
            comando.Parameters.AddWithValue("@name",nome);
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
}