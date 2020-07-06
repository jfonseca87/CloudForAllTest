using System;
using System.Collections.Generic;
using System.Text;

namespace CloudForAllTest.Domain.Models.DTOs
{
    public class FacturaDTO
    {
        public string ProductoId { get; set; }
        public int CantidadProducto { get; set; }
        public string PreventaId { get; set; }
    }
}
