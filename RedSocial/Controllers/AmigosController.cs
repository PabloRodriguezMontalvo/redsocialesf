using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using RedSocial.Models;
using RedSocial.Services;
using RedSocialWebApi.Models;

namespace RedSocial.Controllers
{
    public class AmigosController : Controller
    {
        ServicioAmigos servicio = new ServicioAmigos("http://localhost:49322/api/Amigos"); 
        // GET: Amigos
        public ActionResult MisAmigos()
        {
            var us = Session["usuario"] as Usuario;
            if (us == null)
                return RedirectToAction("Index", "Autenticacion");
            var parametros = new Dictionary<String, Object>()
            {
                {"idUsuario", us.id}

            };
            var amigos = servicio.GetList(parametros);

            return View(amigos);

            
        }

        [HttpPost]
        public async Task<ActionResult> AddAmigo(String txt)
        {
            var us = Session["usuario"] as Usuario;
            if (us == null)
                return RedirectToAction("Index", "Autenticacion");
            var na = new NuevoAmigo()
            {
                Email = txt,
                IdUsuario = us.id
            };

            await servicio.AddNuevoAmigo(na);

            return Json("Ok");
        }


    }
}












