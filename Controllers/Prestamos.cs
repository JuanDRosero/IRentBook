using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models;
using IRentBook.Models.Proxy.ProxyPrestamo;
using IRentBook.Models.Fachada;
using IRentBook.Models.Proxy.ProxyPelicula;
using IRentBook.Models.Proxy.ProxyLibros;

namespace IRentBook.Controllers
{
    public class Prestamos : Controller
    {
        private delegate string TipoP(int? id,int? id2);
        private delegate string NombreU(int id);
        private delegate string NombreP(int? id, int? id2, string tipo);
        // GET: Prestamos
        public ActionResult Index()
        {
            TipoP getTipo = (int? val, int? val2) =>
             {
                 if (val != null)
                 {
                     return "Libro";
                 }
                 else
                     return "Pelicula";
             };
            var mp = new MetodosPrestamos();
            var fachada = new FachadaUsuario();
            var usuarios = fachada.listarU();
            NombreU getNombre = (int value) =>
              {
                  return usuarios.Find(e => e.id == value).nombre;
              };
            List<ModelPrestamoView> listaPrestamos = new List<ModelPrestamoView>();

            var mPelicula = new MetodosPeliculas();
            var ml = new MetodosLibro();

            var peliculas = mPelicula.leerPeliculas();
            var libros = ml.leerLibros();
            NombreP getNombreP = (int? id, int? id2, string tipo) =>
            {
                if (tipo == "Libro")
                {
                    return libros.Find(e => e.id == id).nombre;
                }
                else
                {
                    return peliculas.Find(e => e.id == id2).nombre;
                }
            };

            var prestamos = mp.leerPrestamo();
            foreach (var item in prestamos)
            {
                listaPrestamos.Add(new ModelPrestamoView()
                {
                    id = item.idPrestamo,
                    tipoProducto = getTipo(item.idLibroP, item.idPeliculaP),
                    nombreProducto = getNombreP(item.idLibroP, item.idPeliculaP, getTipo(item.idLibroP, item.idPeliculaP)),
                    nombreUsuario = getNombre(item.idUsuario)
                });
            }
            listaPrestamos.OrderBy(e=>e.nombreUsuario);

            /*
            var consulta = from pres in listaPrestamos
                           group pres by pres.nombreUsuario;
            */
            
            return View(listaPrestamos);
        }


    }
}
