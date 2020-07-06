using MongoDB.Bson.Serialization.Attributes;

namespace CloudForAllTest.Domain
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductoId { get; set; }
        public string NomProducto { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
