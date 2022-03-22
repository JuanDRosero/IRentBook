using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public class ModelPrestamoView
    {
        public int id { get; set; }
        [DisplayName("Tipo")]
        public string tipoProducto { get; set; }
        [DisplayName("Nombre Producto")]
        public  string nombreProducto { get; set; }
        [DisplayName("Nombre Usuario")]
        public string nombreUsuario { get; set; }
    }
}
