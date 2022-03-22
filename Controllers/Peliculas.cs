using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyPelicula;
using IRentBook.Models.Proxy.ProxyGenero;
using IRentBook.Models.Patron_Comando;

namespace IRentBook.Controllers
{
    public class Peliculas : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            //Index de libros
            var rol = HttpContext.Session.GetString("Rol");
            if (rol.Equals(""))
            {
                return RedirectToActionPermanent("Index", "Home");
            }
            MetodosPeliculas metodosPeliculas = new MetodosPeliculas();
            MetodosGenero metodosGenero = new MetodosGenero();
            List<Pelicula> peliculas = metodosPeliculas.leerPeliculas();
            List<Genero> genero = metodosGenero.leerGenero();
            foreach (var pelicula in peliculas)
            {
                pelicula.genero = genero.Where(e => e.id == Int32.Parse(pelicula.genero)).FirstOrDefault().nombre;
            }
            return View(peliculas);
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            Pelicula pelicula = new Pelicula();//Aca hay que inicializar la lista de generos
            MetodosGenero metodosGenero = new MetodosGenero();
            pelicula.listaGeneros = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(getListaG(metodosGenero));
            return View(pelicula);
        }

        // POST: Peliculas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id,nombre,genero,duracion,director")] Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            IComando agregarPelicula = new AgregarPelicula(pelicula);
            ControlInventario invocador = new ControlInventario(agregarPelicula, null, null);
            invocador.agregarProducto();
            return RedirectToAction("Index");
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int id)
        {
            MetodosPeliculas metodosPeliculas = new MetodosPeliculas();
            MetodosGenero metodosGenero = new MetodosGenero();
            var peliculas = metodosPeliculas.leerPeliculas();
            var pelicula = peliculas.Where(e=>e.id == id).FirstOrDefault();
            if (pelicula!=null)
            {
                pelicula.listaGeneros = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(getListaG(metodosGenero));
                return View(pelicula);
            }
            return RedirectToAction("Index");
        }

        // POST: Peliculas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("id,nombre,genero,duracion,director")] Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            IComando editarPelicula = new EditarPelicula(pelicula);
            ControlInventario invocador = new ControlInventario(null, editarPelicula, null);
            invocador.editarProducto();

            return RedirectToAction("Index");
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int id)
        {
            MetodosPeliculas metodosPeliculas = new MetodosPeliculas();
            var peliculas = metodosPeliculas.leerPeliculas();
            var pelicula = peliculas.Where(e => e.id == id).FirstOrDefault();
            if (pelicula!=null)
            {
                IComando eliminarPelicula = new EliminarPelicula(pelicula);
                ControlInventario invocador = new ControlInventario(null, null, eliminarPelicula);
                invocador.eliminarProducto();
            }
            return RedirectToAction("Index");
        }

        private List<String> getListaG(MetodosGenero mg)
        {
            List<Genero> lg = mg.leerGenero();
            List<String> lista = new List<string>();
            var consulta = from genero in lg
                           select genero.nombre;
            foreach (var item in consulta)
            {
                lista.Add(item);
            }
            return lista;
        }

    }
}
