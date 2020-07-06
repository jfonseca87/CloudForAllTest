using System;
using System.ComponentModel.DataAnnotations;

namespace CloudForAllTest.API.Models
{
    public class PreventaApiModel
    {
        [Required]
        public string PreventaId { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El email debe tener un formato válido")]
        public string Email { get; set; }

        [Required]
        public string LugarDespacho { get; set; }

        [Required]
        public DateTime FechaPreventa { get; set; }
    }
}
