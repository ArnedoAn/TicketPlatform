using System.Data.SqlClient;
using System.Data;
using TicketPlatform.Core.Entities;
using TicketPlatform.Core.EntitiesS;
using TicketPlatform.Core.Interfaces;
using TicketPlatform.Infrastructure.Data;

namespace TicketPlatform.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRespository
    {
        private readonly DbContext _dbContext = new();

        public async Task<int> Create(Ticket ticket)
        {
            int id = 0;
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_CrearTicket", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@Descripcion", ticket.Descripcion);
                        command.Parameters.AddWithValue("@Prioridad", ticket.Prioridad);

                        var ticketIdParam = new SqlParameter("@TicketID", SqlDbType.Int);
                        ticketIdParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ticketIdParam);

                        await command.ExecuteNonQueryAsync();

                        id = (int)ticketIdParam.Value;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return id;
            };
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_EliminarTicket", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();
                        command.Parameters.AddWithValue("@id", id);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<Ticket> Get(int id)
        {
            var TicketUnique = new Ticket();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_ObtenerTicket", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@id", id);

                        await command.ExecuteNonQueryAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                TicketUnique.Prioridad = reader.GetString("Prioridad");
                                TicketUnique.Descripcion = reader.GetString("Descripcion");
                                TicketUnique.Id = reader.GetInt32("Id");
                            }

                        }
                    }
                }

                return TicketUnique;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return TicketUnique;
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            var TicketList = new List<Ticket>();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_ListarTickets", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                TicketList.Add(new Ticket
                                {
                                    Prioridad = reader.GetString("Prioridad"),
                                    Descripcion = reader.GetString("Descripcion"),
                                    Id = reader.GetInt32("Id")
                                });
                            }

                        }
                    }
                }

                return TicketList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return TicketList;
            }
        }

        public async Task<bool> Update(Ticket ticket)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_EditarTicket", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@id", ticket.Id);
                        command.Parameters.AddWithValue("@Descripcion", ticket.Descripcion);
                        command.Parameters.AddWithValue("@Prioridad", ticket.Prioridad);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            };
        }
    }


}
