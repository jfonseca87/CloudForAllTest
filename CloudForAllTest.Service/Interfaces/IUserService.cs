using System.Threading.Tasks;
using CloudForAllTest.Domain.Models;

namespace CloudForAllTest.Service.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<bool> ExistsUsers();
        Task<string> Login(User user);
    }
}
