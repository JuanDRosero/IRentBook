using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*using IRentBook.Models.Proxy.ProxyPelicula;
using IRentBook.Models.Proxy.ProxyGenero;
using IRentBook.Models.Patron_Comando;*/
using IRentBook.Logica.Edu;

namespace IRentBook.Controllers
{
    public class Peliculas : Controller
    {
        private readonly FactoryProducto fabrica;
        private readonly Orquestador orquestador;
        public Peliculas()
        {
            fabrica = new FactoryProducto();
        }
        // GET: Peliculas
        public ActionResult Index()
        {
            //Index de libros
            var rol = HttpContext.Session.GetString("Rol");
            if (rol.Equals(""))
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            List<Api.Edu.Modelo.Pelicula> peliculas = orquestador.ModerarLeerP(null);
            List<Api.Edu.Modelo.Genero> genero = orquestador.ModerarLeerG();
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
            var pelicula = fabrica.crearProducto('p');//Aca hay que inicializar la lista de generos
            //MetodosGenero metodosGenero = new MetodosGenero();
            pelicula.listaGeneros = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(getListaG());
            return View(pelicula);
        }

        // POST: Peliculas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id,nombre,genero,duracion,director")] Api.Edu.Modelo.Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            orquestador.ModerarCrear(pelicula);
            return RedirectToAction("Index");
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int id)
        {
            var peliculas = orquestador.ModerarLeerP(null);
            var pelicula = peliculas.Where(e=>e.id == id).FirstOrDefault();
            if (pelicula!=null)
            {
                pelicula.listaGeneros = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(getListaG());
                return View(pelicula);
            }
            return RedirectToAction("Index");
        }

        // POST: Peliculas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("id,nombre,genero,duracion,director")] Api.Edu.Modelo.Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            orquestador.ModerarEditar(pelicula);
            return RedirectToAction("Index");
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int id)
        {
            var peliculas = orquestador.ModerarLeerP(null);
            var pelicula = peliculas.Where(e => e.id == id).FirstOrDefault();
            if (pelicula!=null)
            {
                /*IComando eliminarPelicula = new EliminarPelicula(pelicula);
                ControlInventario invocador = new ControlInventario(null, null, eliminarPelicula);
                invocador.eliminarProducto();*/
                orquestador.ModerarEliminar(pelicula);
            }
            return RedirectToAction("Index");
        }

        private List<String> getListaG()
        {
            List<Api.Edu.Modelo.Genero> lg = orquestador.ModerarLeerG();
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
