using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Prestamo
    {
        public int idPrestamo { get; set; }
        public int? idLibroP { get; set; }
        public int? idPeliculaP { get; set; }
        public int idUsuario { get; set; }
    }
}
