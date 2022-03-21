using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Patron_Comando
{
    public class EditarPelicula
    {
        private Pelicula producto { get; set; }
        public EditarPelicula(Pelicula producto)
        {
            this.producto = producto;
        }
        public bool ejecutar()
        {
            //Aca va la logica de editar producto
            return true;
        }
    }
}
