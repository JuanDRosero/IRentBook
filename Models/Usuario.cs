using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IRentBook.Models
{
    public class Usuario: Persona
    {

        [Required(ErrorMessage = "El campo direccion es requerido")]
        [DisplayName("Dirección")]
        public string direccion { get; set; }
    }
}
