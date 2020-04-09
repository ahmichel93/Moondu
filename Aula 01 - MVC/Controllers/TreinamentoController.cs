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
        public ActionResult Lista()
        {
            TreinamentoListaViewModel lista = new TreinamentoListaViewModel();

            using (Aula01DbCtx context = new Aula01DbCtx())
            {
                lista.ListaTreinamentos = context.Treinamentos.ToList();
            }
            return View(lista);
        }

        public ActionResult Treinamento(int? Codigo)
        {
            TreinamentoViewModel treinamentoViewModel = new TreinamentoViewModel();

            if (Codigo.HasValue)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {
                    Treinamento treinamento = context.Treinamentos.FirstOrDefault(c => c.Codigo == Codigo.Value);

                    if (treinamento != null)
                    {
                        treinamentoViewModel.Codigo = treinamento.Codigo;
                        treinamentoViewModel.Nome = treinamento.Nome;
                        treinamentoViewModel.Descricao = treinamento.Descricao;
                        treinamentoViewModel.Vagas = treinamento.Vagas;
                        treinamentoViewModel.Inicio = treinamento.Inicio;
                        treinamentoViewModel.Final = treinamento.Final;
                        treinamentoViewModel.Local = treinamento.Local;
                        treinamentoViewModel.isEdicao = true;

                        ViewBag.Acao = "Editar";

                    }
                    else
                    {
                        return RedirectToAction("Lista");
                    }
                }
            }
            else
            {
                treinamentoViewModel.isEdicao = false;
                ViewBag.Acao = "Cadastro";
            }

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
                    if (treinamentoView.isEdicao)
                    {

                        Treinamento treinamento = context.Treinamentos.FirstOrDefault(c => c.Codigo == treinamentoView.Codigo);
                        if (treinamento != null)
                        {
                            EditaTreinamento(treinamento, treinamentoView);
                        }

                        else
                        {
                            return RedirectToAction("Lista");

                        }
                    }
                    else
                    {
                        //Validação se o usuário ja existe no banco de dados
                        Treinamento treinamento_Codigo = context.Treinamentos.FirstOrDefault(t => t.Codigo == treinamentoView.Codigo);
                        Treinamento treinamento_Nome = context.Treinamentos.FirstOrDefault(c => c.Nome == treinamentoView.Nome);
                        if (treinamento_Codigo != null)
                        {

                            //adiciona mensagem de erro a tela, retornando a tela preenchida
                            ModelState.AddModelError("Codigo", "O Código ja existe");

                            return View(treinamentoView);
                        }
                        if (treinamento_Nome != null)
                        {
                            //adiciona mensagem de erro a tela, retornando a tela preenchida
                            ModelState.AddModelError("Nome", "Esta Nome ja está cadastrado.");

                            return View(treinamentoView);
                        }
                        CadastraTreinamento(treinamentoView);
                    }
                }
                return RedirectToAction("Lista");
            }
            return View(treinamentoView);
        }

        private void CadastraTreinamento(TreinamentoViewModel treinamentoView)
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
        }

        private void EditaTreinamento(Treinamento treinamento, TreinamentoViewModel treinamentoView)
        {
            using (Aula01DbCtx context = new Aula01DbCtx())
            {
                treinamento.Codigo = treinamentoView.Codigo.Value;
                treinamento.Nome = treinamentoView.Nome;
                treinamento.Descricao = treinamentoView.Descricao;
                treinamento.Vagas = treinamentoView.Vagas.Value;
                treinamento.Inicio = treinamentoView.Inicio;
                treinamento.Final = treinamentoView.Final;
                treinamento.Local = treinamentoView.Local;
           
                context.SaveChanges();
            }
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