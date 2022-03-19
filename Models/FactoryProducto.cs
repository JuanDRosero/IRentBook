using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class FactoryProducto : IFactoryMethodProducto
    {
        public Producto crearProducto(char producto)
        {
            switch (producto)
            {
                case 'p': return new Pelicula();
                case 'l': return new Libro();
                default: return null;
            }
        }
    }
}
