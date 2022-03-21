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
        public void agregarProducto()
        {
            agregarInv.ejecutar();
        }
        public void editarProducto()
        {
            editarInv.ejecutar();
        }
        public void eliminarProducto()
        {
            eliminarInv.ejecutar();
        }
    }
}
