using CloudForAllTest.Domain;
using CloudForAllTest.Domain.Models;
using MongoDB.Driver;

namespace CloudForAllTest.Repository.MongoImplementations
{
    public class TestContext
    {
        private readonly string dbServer = Global.MongoConn;
        private readonly string dbName = Global.MongoDatabase;
        private readonly IMongoDatabase db;

        private enum Collections
        {
            Facturas,
            Preventas,
            Productos,
            Usuarios
        }

        public TestContext()
        {
            MongoClient client = new MongoClient(dbServer);
            db = client.GetDatabase(dbName);
        }

        public IMongoCollection<Factura> Facturas
        {
            get
            {
                return db.GetCollection<Factura>(Collections.Facturas.ToString());
            }
        }

        public IMongoCollection<Preventa> Preventas
        {
            get
            {
                return db.GetCollection<Preventa>(Collections.Preventas.ToString());
            }
        }

        public IMongoCollection<Producto> Productos
        {
            get
            {
                return db.GetCollection<Producto>(Collections.Productos.ToString());
            }
        }

        public IMongoCollection<User> Usuarios
        {
            get
            {
                return db.GetCollection<User>(Collections.Usuarios.ToString());
            }
        }
    }
}
