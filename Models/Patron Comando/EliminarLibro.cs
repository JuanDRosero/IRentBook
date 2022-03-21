using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyLibros;

namespace IRentBook.Models.Patron_Comando
{
    public class EliminarLibro: IComando
    {
        private Libro producto { get; set; }
        public EliminarLibro(Libro producto)
        {
            this.producto = producto;
        }
        public void ejecutar()
        {
            //Aca va la logica de eliminar producto
            MetodosLibro metodosLibro = new MetodosLibro();
            metodosLibro.eliminarLibro(producto);
        }
    }
}
