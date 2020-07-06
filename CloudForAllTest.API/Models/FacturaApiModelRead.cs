using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudForAllTest.API.Models
{
    public class FacturaApiModelRead
    {
        public string FacturaId { get; set; }
        public string PreventaId { get; set; }
        public string NomProducto { get; set; }
        public decimal ValorProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}

