using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Controllers
{
    public class Productos : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            //Hay que añadir logica para que pueda filtart por solo peliculas, libros o generos
            return View();
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult CrearPelicula()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPelicula(IFormCollection collection)
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
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPelicula(int id, IFormCollection collection)
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
            return View();
        }
        // GET: Productos/Create
        public ActionResult CrearLibro()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearLibro(IFormCollection collection)
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
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditarLibro(int id, IFormCollection collection)
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
            return View();
        }
    }
}
