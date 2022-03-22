using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class Libro: Producto
    {
        [Required]
        [DisplayName("# Páginas")]
        public int paginas { get; set; }
        [Required]
        [DisplayName("Autores")]
        public  string autores { get; set; }

        public override string getAutor()
        {
            return autores;
        }

        public override string getTamanio()
        {
            return paginas.ToString()+" págs";
        }
    }
}
