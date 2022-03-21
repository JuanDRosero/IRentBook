using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models
{
    public abstract class Producto
    {
        public int id{ get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string nombre{ get; set; }
        [Required]
        [DisplayName("Genero")]
        public string genero{ get; set; }
        public SelectList listaGeneros { get; set; }
        public abstract string getTamanio();
        public abstract string getAutor();

    }
}
