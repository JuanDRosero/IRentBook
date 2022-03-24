using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
//using IRentBook.Models.Proxy.ProxyEmpleados;
//using IRentBook.Models.Fachada;
//using IRentBook.Models.Patron_Cadena;
using IRentBook.Logica.Edu;

namespace IRentBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Orquestador orquestador;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            orquestador = new Orquestador();
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Rol", "");
            HttpContext.Session.SetInt32("Id", -1);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(int codigoUsuario, string password)
        {
            
            try
            {
                var p = orquestador.ModerarLoggearU(codigoUsuario, password);
                if (p == null)
                {
                    _logger.LogInformation("No se ingreso un valor valido");
                    return RedirectToAction("Index");
                }
                else
                {
                    if (p.GetType().Equals(new IRentBook.Models.Usuario().GetType()))   //Redirige a la vista de usuario
                    {
                        HttpContext.Session.SetString("Rol", "User");
                        HttpContext.Session.SetInt32("Id", p.id);
                        return RedirectToAction("Index", "Usuario");
                    }
                    else if (p.GetType().Equals(new IRentBook.Models.Persona().GetType()))
                    {
                        HttpContext.Session.SetString("Rol", "Admin");
                        HttpContext.Session.SetInt32("Id", p.id);
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error");
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
