using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyPelicula;
using IRentBook.Models.Proxy.ProxyLibros;
using IRentBook.Models.Proxy.ProxyGenero;
using IRentBook.Models.Patron_Comando;

namespace IRentBook.Controllers
{
    public class Libros : Controller

    {
        private readonly FactoryProducto fabrica;
        public Libros()
        {
            fabrica = new FactoryProducto();
        }
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
            MetodosGenero mg = new MetodosGenero();
            List<Libro> libros = ml.leerLibros();
            List<Genero> generos = mg.leerGenero();
            foreach (var libro in libros)
            {
                libro.genero = generos.Where(e => e.id == Int32.Parse(libro.genero)).FirstOrDefault().nombre;
            }
            return View(libros);
        }

  

        // GET: Productos/Create
        public ActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            var libro = fabrica.crearProducto('l');
            var mg = new MetodosGenero();
            libro.listaGeneros=new Microsoft.AspNetCore.Mvc.Rendering.SelectList(getListaG(mg));
            return View(libro);
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id,nombre,genero, paginas,autores")]Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            IComando agregarLibro = new AgregarLibro(libro);
            ControlInventario invocador = new ControlInventario(agregarLibro,null,null);
            invocador.agregarProducto();
            return RedirectToAction("Index");
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            MetodosLibro ml = new MetodosLibro();
            List<Libro> libros = ml.leerLibros();
            Libro libro =libros.Where(e=>e.id==id).FirstOrDefault();
            
            if (libro!=null)
            {
                var mg = new MetodosGenero();
                libro.listaGeneros = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(getListaG(mg));
                return View(libro);
            }
            return RedirectToAction("Index");
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("id,nombre,genero, paginas,autores")] Libro libro)
        {
            if (libro != null && ModelState.IsValid)
            {
                IComando editarLibro = new EditarLibro(libro);
                ControlInventario invocador = new ControlInventario(null,editarLibro,null);
                invocador.editarProducto();
            }
            return RedirectToAction("Index");
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("Admin"))
            {
                //Un usuario no puede usar este metodo
                return RedirectToActionPermanent("Index", "Home");
            }
            MetodosLibro ml = new MetodosLibro();
            List<Libro> libros = ml.leerLibros();
            Libro libro = libros.Where(e => e.id == id).FirstOrDefault();
            IComando eliminarLibro = new EliminarLibro(libro);
            ControlInventario invocador = new ControlInventario(null,null, eliminarLibro);
            invocador.eliminarProducto();
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
