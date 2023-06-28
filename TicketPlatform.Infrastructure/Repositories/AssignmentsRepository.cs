﻿using TicketPlatform.Core.Entities;
using TicketPlatform.Core.Interfaces;
using TicketPlatform.Infrastructure.Data;
using System.Data.SqlClient;
using System.Data;
using TicketPlatform.Core.EntitiesS;

namespace TicketPlatform.Infrastructure.Repositories
{
    public class AssignmentsRepository : IAssignmentsRepository
    {
        private readonly DbContext _dbContext = new();

        public async Task<bool> Create(Assignments assignment)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_CrearAsignacion", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@idUsuario", assignment.User.Id);
                        command.Parameters.AddWithValue("@idTicket", assignment.Ticket.Id);
                        command.Parameters.AddWithValue("@idEstado", assignment.Status);

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

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_EliminarAsignacion", connection))
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

        public async Task<Assignments> Get(int id)
        {

            var AssignmentsUnique = new Assignments();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {

                    using (var command = new SqlCommand("sp_ObtenerAsignacion", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id);

                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {

                                User user = new()
                                {
                                    Nombre = reader.GetString("NombreUsuario"),
                                    Id = reader.GetInt32("idUsuario"),
                                    Cedula = reader.GetString("Cedula")
                                };

                                Ticket ticket = new()
                                {
                                    Id = reader.GetInt32("idTicket"),
                                    Priority = reader.GetString("Prioridad"),
                                    Description = reader.GetString("Description")
                                };

                                AssignmentsUnique.Status = reader.GetInt32("ïdEstado");
                                AssignmentsUnique.Ticket = ticket;
                                AssignmentsUnique.User = user;

                            }

                        }

                    }
                }

                return AssignmentsUnique;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return AssignmentsUnique;
            }

        }

        public async Task<IEnumerable<Assignments>> GetAll()
        {
            var AssignmentsList = new List<Assignments>();

            try
            {
                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_ListarAsignaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                User user = new()
                                {
                                    Nombre = reader.GetString("NombreUsuario"),
                                    Id = reader.GetInt32("idUsuario"),
                                    Cedula = reader.GetString("Cedula")
                                };

                                Ticket ticket = new()
                                {
                                    Id = reader.GetInt32("idTicket"),
                                    Priority = reader.GetString("Prioridad"),
                                    Description = reader.GetString("Descripcion")
                                };

                                AssignmentsList.Add(new Assignments
                                {
                                    Ticket = ticket,
                                    User = user,
                                    Status = reader.GetInt32("idEstado")
                                });
                            }

                        }

                    }
                }

                return AssignmentsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return AssignmentsList;
            }


        }

        public async Task<bool> Update(Assignments assignment)
        {
            try
            {

                using (var connection = new SqlConnection(_dbContext.ConnectionString()))
                {
                    using (var command = new SqlCommand("sp_EditarAsignacion", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        command.Parameters.AddWithValue("@idUsuario", assignment.User.Id);
                        command.Parameters.AddWithValue("@idTicket", assignment.Ticket.Id);
                        command.Parameters.AddWithValue("@idEstado", assignment.Status);

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

    }
}