using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.Entities;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(UsersPostDto userDto)
        {
            User user = new User
            {
                Cedula = userDto.Cedula,
                Nombre = userDto.Name
            };

            return await _userRepository.Create(user);

        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<bool> UpdateUser(UsersPutDto userDto)
        {
            User user = new User
            {
                Id = userDto.Id,
                Cedula = userDto.Cedula,
                Nombre = userDto.Name
            };

            return await _userRepository.Update(user);
        }
    }
}
