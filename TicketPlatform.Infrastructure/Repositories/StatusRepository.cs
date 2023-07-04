using System.Data.SqlClient;
using System.Data;
using System.Text;
using TicketPlatform.Core.Entities;
using TicketPlatform.Core.Interfaces;
using TicketPlatform.Infrastructure.Data;

namespace TicketPlatform.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {

        private readonly DbContext _dbContext = new();

        public StatusRepository() { }

        public async Task<IEnumerable<Status>> GetAllStatus()
        {
            var StatusList = new List<Status>();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_ListarEstados", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                StatusList.Add(new Status
                                {
                                    Id = reader.GetInt32("Id"),
                                    Nombre = reader.GetString("Nombre"),
                                });
                            }

                        }
                    }
                }

                return StatusList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusList;
            }
        }
    }
}
