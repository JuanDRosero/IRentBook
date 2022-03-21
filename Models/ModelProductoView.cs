using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class ModelProductoView
    {
        public List<Libro> libros { get; set; }
        public List<Pelicula> peliculas { get; set; }
    }
}
