using IRentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login( string name, string password)
        {
            if (password.Equals("123456789"))   //Redirige a la vista de usuario
            {
                return RedirectToAction("Index", "Usuario");
            }
            else if (password.Equals("987654321"))
            {
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
