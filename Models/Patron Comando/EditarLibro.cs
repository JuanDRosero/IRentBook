using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyLibros;

namespace IRentBook.Models.Patron_Comando
{
    public class EditarLibro
    {
        private Libro producto { get; set; }
        public EditarLibro(Libro producto)
        {
            this.producto = producto;
        }
        public void ejecutar()
        {
            //Aca va la logica de editar producto
            MetodosLibro metodosLibro = new MetodosLibro();
            metodosLibro.editarLibro(producto);
        }
    }
}
