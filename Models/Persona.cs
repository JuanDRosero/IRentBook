using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Persona
    {
        public int id { get; set; }
        [Required(ErrorMessage ="El campo codigo es requerido")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="El valor de Codigo no es valido")]
        [DisplayName("Codigo")]
        public int codigo { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string pass { get; set; }
    }
}
