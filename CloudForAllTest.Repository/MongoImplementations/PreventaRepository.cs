using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Repository.Interfaces;
using MongoDB.Driver;

namespace CloudForAllTest.Repository.MongoImplementations
{
    public class PreventaRepository : IPreventaRepository
    {
        private readonly TestContext db;

        public PreventaRepository()
        {
            db = new TestContext();
        }

        public async Task CreatePreventa(Preventa preventa)
        {
            await db.Preventas.InsertOneAsync(preventa);
        }

        public async Task DeletePreventa(string id)
        {
            FilterDefinition<Preventa> filter = Builders<Preventa>.Filter.Eq("PreventaId", id);
            await db.Preventas.DeleteOneAsync(filter);
        }

        public async Task<Preventa> GetPreventa(string id)
        {
            FilterDefinition<Preventa> filter = Builders<Preventa>.Filter.Eq("PreventaId", id);
            return await db.Preventas.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Preventa>> GetPreventas()
        {
            return await db.Preventas.Find(FilterDefinition<Preventa>.Empty).ToListAsync();
        }

        public async Task UpdatePreventa(Preventa preventa)
        {
            FilterDefinition<Preventa> filter = Builders<Preventa>.Filter.Eq("PreventaId", preventa.PreventaId);
            await db.Preventas.ReplaceOneAsync(filter, preventa);
        }
    }
}
