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
        public ActionResult Lista()
        {
            ColaboradorListaViewModel lista = new ColaboradorListaViewModel();

            using (Aula01DbCtx context = new Aula01DbCtx())
            {
               
                lista.ListaColaboradores = context.Colaboradores.ToList();
            }
             return View(lista);
        }

        public ActionResult Colaborador(int? Matricula)
        {
            ColaboradorViewModel colaboradorViewModel = new ColaboradorViewModel();

            if (Matricula.HasValue)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {
                    Colaborador colaborador = context.Colaboradores.FirstOrDefault(c => c.Matricula == Matricula.Value);

                    if (colaborador != null)
                    {
                        colaboradorViewModel.Nome = colaborador.Nome;
                        colaboradorViewModel.Email = colaborador.Email;
                        colaboradorViewModel.Gestor = colaborador.Gestor;
                        colaboradorViewModel.Telefone = colaborador.Telefone;
                        colaboradorViewModel.Matricula = colaborador.Matricula;
                        colaboradorViewModel.isEdicao = true;

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
                colaboradorViewModel.isEdicao = false;
                ViewBag.Acao = "Cadastro";
            }

            return View(colaboradorViewModel);
        }


        //POST
        [HttpPost]

        public ActionResult Colaborador(ColaboradorViewModel colaboradorView)
        {
            if (HttpContext.Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {
                    if (colaboradorView.isEdicao) {
                        Colaborador colaborador = context.Colaboradores.FirstOrDefault(c => c.Matricula == colaboradorView.Matricula);
                        if(colaborador != null)
                        {
                            colaborador.Nome = colaboradorView.Nome;
                            colaborador.Matricula = colaboradorView.Matricula.Value;
                            colaborador.Email = colaboradorView.Email;
                            colaborador.Gestor = colaboradorView.Gestor;
                            
                            if (colaboradorView.Telefone.HasValue)
                                colaborador.Telefone = colaboradorView.Telefone.Value;

                            context.SaveChanges();
                        }
                        
                        else
                        {
                            return RedirectToAction("Lista");

                        }
                    }

                    else 
                    { 
                    //Validação se o usuário ja existe no banco de dados
                    Colaborador colaborador_matricula = context.Colaboradores.FirstOrDefault(c => c.Matricula == colaboradorView.Matricula);
                    Colaborador colaborador_nome = context.Colaboradores.FirstOrDefault(c => c.Nome == colaboradorView.Nome);
                        if (colaborador_matricula != null)
                            {
                            //adiciona mensagem de erro a tela, retornando a tela preenchida
                            ModelState.AddModelError("Matricula", "Esta matrícula ja está cadastrada.");

                            return View(colaboradorView);
                            }
                        if (colaborador_nome != null)
                            {
                            //adiciona mensagem de erro a tela, retornando a tela preenchida
                            ModelState.AddModelError("Nome", "Esta Nome ja está cadastrado.");

                            return View(colaboradorView);
                            }
                    }
                    CadastraColaborador(colaboradorView);
                }
                return RedirectToAction("Lista");
            }
            return View(colaboradorView);
        }

        private void CadastraColaborador(ColaboradorViewModel colaboradorView)
        {

            using (Aula01DbCtx context = new Aula01DbCtx()) { 
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
        }



        public ActionResult Deletar(int Matricula)
        {
            using (Aula01DbCtx context = new Aula01DbCtx())
            {
                Colaborador colaborador = context.Colaboradores.FirstOrDefault(c => c.Matricula == Matricula);

                if(colaborador != null)
                {
                    context.Colaboradores.Remove(colaborador);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("lista");
        }
    }
}