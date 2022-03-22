using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRentBook.Models.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Controllers
{
    public class Usuarios : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            FachadaUsuario fachada = new FachadaUsuario();
            List<IRentBook.Models.Usuario> usuarios = fachada.listarU();
            var a = HttpContext.Session.GetString("Rol");
            if (HttpContext.Session.GetString("Rol").Equals("Admin"))
            {
                return View(usuarios);  //Hay que pasarle como parametros los usuarios
            } else if (HttpContext.Session.GetString("Rol").Equals("User"))
            {
                RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction("Index", "Home");//Si no hay una sesión iniciada
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("Rol").Equals("Admin"))
            {
                return View();  //Hay que pasarle como parametros los usuarios
            }
            
            return RedirectToAction("Index", "Home");
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id,codigo,nombre,pass,direccion")]IRentBook.Models.Usuario usuario)
        {
            if (!ModelState.IsValid)    //Revisar pq no está validando el modelo
            {
                return View();
            }
            FachadaUsuario fachada = new FachadaUsuario();
            fachada.agregarU(usuario);
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Rol").Equals("Admin"))
            {
                FachadaUsuario fachada = new FachadaUsuario();
                List<IRentBook.Models.Usuario> usuarios = fachada.listarU();

                IRentBook.Models.Usuario usuario = usuarios.Where(e => e.id == id).FirstOrDefault();
                if (usuario != null)
                {
                    return View(usuario);
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Usuarios/Edit/5
        [HttpPost]   //->Revisar como se pine el parametro put en los form
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("id,codigo,nombre,pass,direccion")] IRentBook.Models.Usuario usuario)
        {
            FachadaUsuario fachada = new FachadaUsuario();
            fachada.modificarU(usuario);
            return RedirectToActionPermanent("Index");
        }

        //[HttpDelete]
        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Rol").Equals("Admin"))
            {
                FachadaUsuario fachada = new FachadaUsuario();
                List<IRentBook.Models.Usuario> usuarios = fachada.listarU();
                IRentBook.Models.Usuario usuario = usuarios.Where(e => e.id == id).FirstOrDefault();
                if (usuario != null)
                {
                    fachada.eliminarU(usuario);
                }
                return RedirectToAction("Index");
            }

            return RedirectToActionPermanent("Index", "Home");
            
        }

        
    }
}
