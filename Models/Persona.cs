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
        [Required]
        [DisplayName("Codigo")]
        public int codigo { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string pass { get; set; }
    }
}
