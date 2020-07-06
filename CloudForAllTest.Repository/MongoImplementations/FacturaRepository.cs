using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Repository.Interfaces;
using MongoDB.Driver;

namespace CloudForAllTest.Repository.MongoImplementations
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly TestContext db;

        public FacturaRepository()
        {
            db = new TestContext();
        }

        public async Task<Factura> CreateFactura(Factura factura)
        {
            await db.Facturas.InsertOneAsync(factura);
            return factura;
        }

        public async Task<IEnumerable<Factura>> GetFacturas()
        {
            return await db.Facturas.Find(FilterDefinition<Factura>.Empty).ToListAsync();
        }
    }
}
