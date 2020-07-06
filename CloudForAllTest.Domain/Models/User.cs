using MongoDB.Bson.Serialization.Attributes;

namespace CloudForAllTest.Domain.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UserId { get; set; }
        public string NomUser { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        public string Rol { get; set; }
    }
}
