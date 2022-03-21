using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyGenero
{
    public abstract class AccionesGenero
    {
        public abstract void agregarGenero(Genero genero);
        public abstract void eliminarGenero(Genero genero);
        public abstract void editarGenero(Genero genero);
        public abstract List<Genero> leerGenero();
    }
}
