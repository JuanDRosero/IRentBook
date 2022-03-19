using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Libro: Producto
    {
        public int paginas { private get; set; }
        public  string autores { private get; set; }

        public override string getAutor()
        {
            return autores;
        }

        public override string getTamanio()
        {
            return paginas.ToString();
        }
    }
}
