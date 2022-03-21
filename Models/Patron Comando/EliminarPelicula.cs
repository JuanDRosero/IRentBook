using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyPelicula;

namespace IRentBook.Models.Patron_Comando
{
    public class EliminarPelicula : IComando
    {
        private Pelicula producto { get; set; }
        public EliminarPelicula(Pelicula producto)
        {
            this.producto = producto;
        }
        public void ejecutar()
        {
            //Aca va la logica de eliminar producto
            MetodosPeliculas metodosPeliculas = new MetodosPeliculas();
            metodosPeliculas.eliminarPelicula(producto);
        }
    }
}
