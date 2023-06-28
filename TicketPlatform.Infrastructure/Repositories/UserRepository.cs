using System.Data.SqlClient;
using System.Data;
using TicketPlatform.Core.Entities;
using TicketPlatform.Core.Interfaces;
using TicketPlatform.Infrastructure.Data;

namespace TicketPlatform.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext = new();
        public async Task<bool> Create(User user)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_CrearUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@Nombre", user.Nombre);
                        command.Parameters.AddWithValue("@Cedula", user.Cedula);

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

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_EliminarUsuario", connection))
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

        public async Task<User> Get(int id)
        {
            var UserUnique = new User();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_ObtenerUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@id", id);

                        await command.ExecuteNonQueryAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {

                                UserUnique.Nombre = reader.GetString("Nombre");
                                UserUnique.Cedula = reader.GetString("Cedula");

                            }

                        }
                    }
                }

                return UserUnique;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return UserUnique;
            }

        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var UserList = new List<User>();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_ListarUsuarios", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                UserList.Add(new User
                                {
                                    Nombre = reader.GetString("Nombre"),
                                    Cedula = reader.GetString("Cedula")
                                });
                            }

                        }
                    }
                }

                return UserList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return UserList;
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_EditarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@Nombre", user.Nombre);
                        command.Parameters.AddWithValue("@Cedula", user.Cedula);
                        command.Parameters.AddWithValue("@id", user.Id);

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
