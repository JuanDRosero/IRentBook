using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyPelicula;

namespace IRentBook.Models.Patron_Comando
{
    public class EditarPelicula
    {
        private Pelicula producto { get; set; }
        public EditarPelicula(Pelicula producto)
        {
            this.producto = producto;
        }
        public void ejecutar()
        {
            //Aca va la logica de editar producto
            MetodosPeliculas metodosPeliculas = new MetodosPeliculas();
            metodosPeliculas.editarPelicula(producto);
        }
    }
}
