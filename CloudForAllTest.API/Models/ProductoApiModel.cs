using System.ComponentModel.DataAnnotations;

namespace CloudForAllTest.API.Models
{
    public class ProductoApiModel
    {
        [Required]
        public string ProductoId { get; set; }

        [Required]
        public string NomProducto { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar un valor unitario válido")]
        public decimal ValorUnitario { get; set; }
    }
}
