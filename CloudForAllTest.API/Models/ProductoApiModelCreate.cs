using System.ComponentModel.DataAnnotations;

namespace CloudForAllTest.API.Models
{
    public class ProductoApiModelCreate
    {
        [Required]
        public string NomProducto { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
