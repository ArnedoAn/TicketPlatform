using Microsoft.Extensions.Configuration;

namespace TicketPlatform.Infrastructure.Data
{
    public class DbContext
    {
        private string connectionString = string.Empty;

        public DbContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = "Server=34.28.194.151,1433;Database=TicketDB;User ID=sqlserver;Password=Andres.23;";

        }

        public string ConnectionString()
        {
            return connectionString;
        }
    }
}
