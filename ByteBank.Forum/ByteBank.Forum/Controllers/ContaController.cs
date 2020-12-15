﻿using ByteBank.Forum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(ContaRegistrarViewModel modelo)
        {
            if(ModelState.IsValid) //Valida se o campo obrigatorio foi preenchido
            {
                //Podemos incluir o usuário
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}