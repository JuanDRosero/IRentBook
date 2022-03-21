using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Controllers
{
    public class Usuario : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (!rol.Equals("User"))
            {
                return RedirectToActionPermanent("Index", "Home");
            }
            return View();
        }


    }
}
