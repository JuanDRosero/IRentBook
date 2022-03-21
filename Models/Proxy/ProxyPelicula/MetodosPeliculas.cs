using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyPelicula
{
    public class MetodosPeliculas: ControlPeliculas
    {
        private ControlPeliculas controlPeliculas;

        public override void agregarPelicula(Pelicula pelicula)
        {
            if (controlPeliculas == null)
            {
                controlPeliculas = new ControlPeliculas();
            }
            controlPeliculas.agregarPelicula(pelicula);
        }

        public override void editarPelicula(Pelicula pelicula)
        {
            if (controlPeliculas == null)
            {
                controlPeliculas = new ControlPeliculas();
            }
            controlPeliculas.editarPelicula(pelicula);
        }

        public override void eliminarPelicula(Pelicula pelicula)
        {
            if (controlPeliculas == null)
            {
                controlPeliculas = new ControlPeliculas();
            }
            controlPeliculas.eliminarPelicula(pelicula);
        }

        public override List<Pelicula> leerPeliculas()
        {
            if (controlPeliculas == null)
            {
                controlPeliculas = new ControlPeliculas();
            }
            return controlPeliculas.leerPeliculas();
        }
    }
}
