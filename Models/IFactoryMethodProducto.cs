using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public interface IFactoryMethodProducto
    {
        public Producto crearProducto(char producto);
    }
}
