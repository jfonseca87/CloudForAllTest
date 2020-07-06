using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudForAllTest.Domain
{
    public class Factura
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string FacturaId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime FacturaFecha { get; set; }
        public Preventa Preventa { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
