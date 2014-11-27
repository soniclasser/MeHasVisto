using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeHasVisto.Models;

namespace MeHasVisto.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/
        public ActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Send(MessageModel modeloDelMensaje)
        {
            //Agregando lógica de validación
            if (string.IsNullOrEmpty(modeloDelMensaje.From))
            {
                ModelState.AddModelError("From",
                    "El campo From (De) es requerido.");
            }
            if (string.IsNullOrEmpty(modeloDelMensaje.Email))
            {
                ModelState.AddModelError("Email",
                    "El campo Email" +
                    "(Direccion de correo electronico) es requerido.");
            }
            if (string.IsNullOrEmpty(modeloDelMensaje.Message))
            {
                ModelState.AddModelError("Message",
                    "El campo Message (Mensaje) es requerido.");
            }



            if (ModelState.IsValid)
            {
                return RedirectToAction("ThankYou");
            }
            ModelState.AddModelError
                ("", "Uno o mas errores fueron encontrados");
           
            return View(modeloDelMensaje);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
