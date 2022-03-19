using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public abstract class Producto
    {
        public int id{ get; set; }
        public string nombre{ get; set; }
        public Genero genero{ get; set; }

        public abstract string getTamanio();
        public abstract string getAutor();

    }
}
