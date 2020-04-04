using Aula_01___MVC.Models;
using Aula_01___MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_01___MVC.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET:
        public ActionResult Index()
        {
            ColaboradorViewModel colaboradorViewModel = new ColaboradorViewModel();

            return View(colaboradorViewModel);
        }


        //POST
        [HttpPost]

        public ActionResult Index(ColaboradorViewModel colaboradorView)
        {
            if (HttpContext.Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {
                    Colaborador colaborador = new Colaborador()
                    {
                       Matricula = colaboradorView.Matricula.Value,
                        Nome = colaboradorView.Nome,
                        Email = colaboradorView.Email,
                        Gestor = colaboradorView.Gestor,
                    };
                    if (colaboradorView.Telefone.HasValue)
                        colaborador.Telefone = colaboradorView.Telefone.Value;

                    context.Colaboradores.Add(colaborador);
                    context.SaveChanges();

                }
                return RedirectToAction("Retorno", "Home");
            }
            return View(colaboradorView);
        }
        public ActionResult Retorno()
        {
            return View();
        }
    }
}