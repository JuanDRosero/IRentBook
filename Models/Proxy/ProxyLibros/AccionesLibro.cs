using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyLibros
{
    public abstract class AccionesLibro
    {
        //clase Subject
        public abstract void agregarLibro(Libro libro);
        public abstract void eliminarLibro(Libro libro);
        public abstract void editarLibro(Libro libro);
        public abstract List<Libro> leerLibros();
    }
}
