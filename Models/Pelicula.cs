using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Pelicula : Producto
    {
        [Required(ErrorMessage ="El campo Duración es reuqerido")]
        [DisplayName("Duración (min)")]
        public int duracion { get; set; }
        [Required(ErrorMessage ="El campo director es requerido")]
        [DisplayName("Director")]
        public string director {  get; set; }
        public override string getAutor()
        {
            return director;
        }

        public override string getTamanio()
        {
            return $"{duracion/60} horas y {duracion%60} minutos";
        }
    }
}
