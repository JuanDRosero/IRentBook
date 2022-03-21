using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyPrestamo
{
    public class MetodosPrestamos: ControlPrestamos
    {
        private ControlPrestamos controlPrestamos;
        public override void agregarPrestamo(Prestamo prestamo)
        {
            if (controlPrestamos == null)
            {
                controlPrestamos = new ControlPrestamos();
            }
            controlPrestamos.agregarPrestamo(prestamo);
        }
        public override void editarPrestamo(Prestamo prestamo)
        {
            if (controlPrestamos == null)
            {
                controlPrestamos = new ControlPrestamos();
            }
            controlPrestamos.editarPrestamo(prestamo);
        }
        public override void eliminarPrestamo(Prestamo prestamo)
        {
            if (controlPrestamos == null)
            {
                controlPrestamos = new ControlPrestamos();
            }
            controlPrestamos.eliminarPrestamo(prestamo);
        }
        public override List<Prestamo> leerPrestamo()
        {
            if (controlPrestamos == null)
            {
                controlPrestamos = new ControlPrestamos();
            }
            return controlPrestamos.leerPrestamo();
        }
    }
}
