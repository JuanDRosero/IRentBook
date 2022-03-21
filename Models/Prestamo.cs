using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Prestamo
    {
        public int idPrestamo { get; set; }
        public int idLibroP { get; set; }
        public int idPeliculaP { get; set; }
        public string nombreProducto { get; set; }
        public string nombreUsuario { get; set; }
        public string direccionUsuario { get; set; }
    }
}
