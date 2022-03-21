using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyPrestamo
{
    public abstract class AccionesPrestamos
    {
        public abstract void agregarPrestamo(Prestamo prestamo);
        public abstract void eliminarPrestamo(Prestamo prestamo);
        public abstract void editarPrestamo(Prestamo prestamo);
        public abstract List<Prestamo> leerPrestamo();
    }
}
