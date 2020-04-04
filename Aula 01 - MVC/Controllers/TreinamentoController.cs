using Aula_01___MVC.Models;
using Aula_01___MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_01___MVC.Controllers
{
    public class TreinamentoController : Controller
    {
       //GET:
        public ActionResult Index()
        {
            TreinamentoViewModel treinamentoViewModel = new TreinamentoViewModel();

            return View(treinamentoViewModel);
        }
        //POST
        [HttpPost]

        public ActionResult Index(TreinamentoViewModel treinamentoView)
        {
            if (HttpContext.Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {
                    Treinamento treinamento = new Treinamento()
                    {
                        Codigo = treinamentoView.Codigo.Value,
                        Nome = treinamentoView.Nome,
                        Descricao = treinamentoView.Descricao,
                        Vagas = treinamentoView.Vagas.Value,
                        Inicio = treinamentoView.Inicio,
                        Final = treinamentoView.Final,
                        Local = treinamentoView.Local,
                    };

                    context.Treinamentos.Add(treinamento);
                    context.SaveChanges();

                }
                return RedirectToAction("Retorno", "Home");
            }
            return View(treinamentoView);
        }
        public ActionResult Retorno()
        {
            return View();
        }
    }
}