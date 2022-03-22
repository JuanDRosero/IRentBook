using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models.Proxy.ProxyEmpleados;
using IRentBook.Models.Fachada;
using IRentBook.Models.Patron_Cadena;

namespace IRentBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Rol", "");
            HttpContext.Session.SetInt32("Id", -1);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(int name, string password)
        {
            IRentBook.Models.Patron_Cadena.Persona h1 = new IRentBook.Models.Patron_Cadena.Empleado();
            IRentBook.Models.Patron_Cadena.Persona h2 = new IRentBook.Models.Patron_Cadena.Usuario();

            h2.SetSucc(h1);

            var p = h2.EncontrarUsEm(name, password);

            if (p.GetType().Equals(new Usuario().GetType()))   //Redirige a la vista de usuario
            {
                HttpContext.Session.SetString("Rol", "User");
                HttpContext.Session.SetInt32("Id", p.id);
                return RedirectToAction("Index", "Usuario");
            }
            else if (p.GetType().Equals(new Empleado().GetType()))
            {
                HttpContext.Session.SetString("Rol", "Admin");
                HttpContext.Session.SetInt32("Id", p.id);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                _logger.LogInformation("No se ingreso un valor valido");
                return RedirectToAction("Index");
            }

            //hace falta redireccionar a la de usuario
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
