using System.ComponentModel.DataAnnotations;

namespace CloudForAllTest.API.Models
{
    public class FacturaApiModel
    {
        [Required]
        public string ProductoId { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar una catidad de producto válida")]
        public int CantidadProducto { get; set; }

        [Required]
        public string PreventaId { get; set; }
    }
}
