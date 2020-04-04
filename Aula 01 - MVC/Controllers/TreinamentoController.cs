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

        public ActionResult Lista()
        {
            TreinamentoListaViewModel lista = new TreinamentoListaViewModel();
        
            using (Aula01DbCtx context = new Aula01DbCtx())
            {
               lista.ListaTreinamentos = context.Treinamentos.ToList();
            }
            return View(lista);
        }

        

       //GET:
        public ActionResult Treinamento()
        {
            TreinamentoViewModel treinamentoViewModel = new TreinamentoViewModel();

            return View(treinamentoViewModel);
        }
        //POST
        [HttpPost]

        public ActionResult Treinamento(TreinamentoViewModel treinamentoView)
        {
            if (HttpContext.Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {

                    Treinamento treinamento_Codigo = context.Treinamentos.FirstOrDefault(t => t.Codigo == treinamentoView.Codigo);
                    if(treinamento_Codigo != null)
                    {
                        ModelState.AddModelError("Codigo", "O Código ja existe");

                        return View(treinamentoView);
                    }
                                                         
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
                return RedirectToAction("Lista");
            }
            return View(treinamentoView);
        }
        public ActionResult Deletar(int Codigo)
        {
            using (Aula01DbCtx context = new Aula01DbCtx())
            {
                Treinamento treinamento = context.Treinamentos.FirstOrDefault(t => t.Codigo == Codigo);

                if (treinamento != null)
                {
                    context.Treinamentos.Remove(treinamento);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("lista");
        }
    }
}