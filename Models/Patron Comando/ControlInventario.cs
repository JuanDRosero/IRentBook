using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Patron_Comando
{
    public class ControlInventario
    {
        private IComando agregarInv { get; set; }
        private IComando editarInv { get; set; }
        public IComando eliminarInv { get; set; }
        public ControlInventario(IComando agregarInv, IComando editarInv, IComando eliminarInv)
        {
            this.agregarInv = agregarInv;
            this.editarInv = editarInv;
            this.eliminarInv = eliminarInv;
        }
        public bool agregarProducto()
        {
            return agregarInv.ejecutar();
        }
        public bool editarProducto()
        {
            return editarInv.ejecutar();
        }
        public bool eliminarProducto()
        {
            return eliminarInv.ejecutar();
        }
    }
}
