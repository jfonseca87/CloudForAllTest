using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudForAllTest.API.Models
{
    public class FacturaReponseModel
    {
        public string ProcesoVenta { get; set; }
        public string FacturaId { get; set; }
        public decimal ValorFactura { get; set; }
        public string Despacho { get; set; }
    }
}
