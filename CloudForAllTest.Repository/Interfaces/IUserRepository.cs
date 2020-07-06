using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain.Models;

namespace CloudForAllTest.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> Login(User user);
    }
}
