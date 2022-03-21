using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyPelicula;
using IRentBook.Models.Proxy.ProxyLibros;

namespace IRentBook.Controllers
{
    public class Libros : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            //Index de libros
            var rol = HttpContext.Session.GetString("Rol");
            if (rol.Equals(""))
            {
                return RedirectToActionPermanent("Index", "Home");
            }
            MetodosLibro ml = new MetodosLibro();
            List<Libro> libros = ml.leerLibros();
            return View(libros);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult CrearPelicula()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            Pelicula pelicula = null ;//Aca hay que inicializar la lista de generos
            return View(pelicula);
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPelicula([Bind("id,nombre,genero,duracion,director")]Pelicula pelicula)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult EditarPelicula(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPelicula([Bind("id,nombre,genero,duracion,director")] Pelicula pelicula)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        [HttpDelete]
        public ActionResult BorrarPelicula(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            return View();
        }
        // GET: Productos/Create
        public ActionResult CrearLibro()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            Libro libro = null;
            return View(libro);
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearLibro([Bind("id,nombre,genero, duracion,director")]Pelicula pelicula)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult EditarLibro(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditarLibro([Bind("id,nombre,genero, duracion,director")] Pelicula pelicula)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        [HttpDelete]
        public ActionResult BorrarLibro(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            return View();
        }
    }
}
