namespace HelpDevs.Services
{
    public class PostService
    {
        private readonly string _connectionString;

        public PostService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


    }
}