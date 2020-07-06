using System;
using System.Linq;
using System.Threading.Tasks;
using CloudForAllTest.Domain.Models;
using CloudForAllTest.Repository.Interfaces;
using CloudForAllTest.Service.Interfaces;
using CloudForAllTest.Service.Utilities;

namespace CloudForAllTest.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task CreateUser(User user)
        {
            await userRepository.CreateUser(user);
        }

        public async Task<bool> ExistsUsers()
        {
            var users = await userRepository.GetUsers();
            return users.Any();
        }

        public async Task<string> Login(User user)
        {
            user.Contrasena = Password.CreateMD5Password(user.Contrasena);

            User userResult = await userRepository.Login(user);
            string token = userResult != null ? Guid.NewGuid().ToString() : null;

            return token;
        }
    }
}
