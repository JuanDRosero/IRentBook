using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Patron_Comando
{
    public class EliminarInventario: IComando
    {
        private Producto producto { get; set; }
        public EliminarInventario(Producto producto)
        {
            this.producto = producto;
        }
        public bool ejecutar()
        {
            //Aca va la logica de eliminar producto
            return true;
        }
    }
}
