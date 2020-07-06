using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain.Models;
using CloudForAllTest.Repository.Interfaces;
using MongoDB.Driver;

namespace CloudForAllTest.Repository.MongoImplementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TestContext db;

        public UserRepository()
        {
            db = new TestContext();
        }

        public async Task CreateUser(User user)
        {
            await db.Usuarios.InsertOneAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Usuarios.Find(FilterDefinition<User>.Empty).ToListAsync();
        }

        public async Task<User> Login(User user)
        {
            return await db.Usuarios.Find(x => x.NomUser.Equals(user.NomUser) && x.Contrasena.Equals(user.Contrasena)).FirstOrDefaultAsync();
        }
    }
}
