using System;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudForAllTest.Domain
{
    public class Preventa
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string PreventaId { get; set; }
        public string LugarDespacho { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime FechaPreventa { get; set; }
        public string Email { get; set; }
    }
}
