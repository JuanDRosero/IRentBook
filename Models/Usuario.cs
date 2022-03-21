using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IRentBook.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Codigo")]
        public int codigo { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string pass { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public string direccion { get; set; }
    }
}
