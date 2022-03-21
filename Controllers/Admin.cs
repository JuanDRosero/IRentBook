﻿using IRentBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Controllers
{
    public class Admin : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //Get: Inventario
        public ActionResult Inventario()
        {
            return View();//->Remitir al controlador
        }

        //Get: usuarios
        public ActionResult Usuarios()
        {
            return View(); //Hay que Remitir al controlador
        }
        public ActionResult LogOut()
        {
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}
//Post: Crear
//Put: para editar
//Delete: para eliminar