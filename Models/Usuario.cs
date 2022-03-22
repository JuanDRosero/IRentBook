using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IRentBook.Models
{
    public class Usuario: Persona
    {

        [Required]
        [DisplayName("Dirección")]
        public string direccion { get; set; }
    }
}
