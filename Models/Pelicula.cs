using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Pelicula : Producto
    {
        public int duracion { private get; set; }
        public string director {  private get; set; }
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
