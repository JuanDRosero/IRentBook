using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Controllers
{
    public class Prestamos : Controller
    {
        // GET: Prestamos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestamos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prestamos/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        [HttpDelete]
        // GET: Prestamos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
