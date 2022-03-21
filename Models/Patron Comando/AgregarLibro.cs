﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyLibros;

namespace IRentBook.Models.Patron_Comando
{
    public class AgregarLibro:IComando
    {
        private  Libro producto { get; set; }
        public AgregarLibro(Libro producto)
        {
            this.producto = producto;
        }
        public void ejecutar()
        {
            //Aca va la logica de agregar u producto
            MetodosLibro metodosLibro = new MetodosLibro();
            metodosLibro.agregarLibro(producto);
        }

    }
}
//https://es.wikipedia.org/wiki/Command_(patr%C3%B3n_de_dise%C3%B1o)