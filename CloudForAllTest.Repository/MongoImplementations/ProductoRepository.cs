using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Repository.Interfaces;
using MongoDB.Driver;

namespace CloudForAllTest.Repository.MongoImplementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TestContext db;

        public ProductoRepository()
        {
            db = new TestContext();
        }

        public async Task CreateProducto(Producto producto)
        {
            await db.Productos.InsertOneAsync(producto);
        }

        public async Task DeleteProducto(string id)
        {
            FilterDefinition<Producto> filter = Builders<Producto>.Filter.Eq("ProductoId", id);
            await db.Productos.DeleteOneAsync(filter);
        }

        public async Task<Producto> GetProducto(string id)
        {
            FilterDefinition<Producto> filter = Builders<Producto>.Filter.Eq("ProductoId", id);
            return await db.Productos.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await db.Productos.Find(FilterDefinition<Producto>.Empty).ToListAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            FilterDefinition<Producto> filter = Builders<Producto>.Filter.Eq("ProductoId", producto.ProductoId);
            await db.Productos.ReplaceOneAsync(filter, producto);
        }
    }
}
