using Aula_01___MVC.Models;
using Aula_01___MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_01___MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            PessoaViewModel pessoaViewModel = new PessoaViewModel();
            
            return View(pessoaViewModel);
        }

        //POST
        [HttpPost]
        public ActionResult Index(PessoaViewModel pessoaView)
           
        {
            if (HttpContext.Request.HttpMethod == "POST" && ModelState.IsValid)
            { 
                using(Aula01DbCtx context = new Aula01DbCtx())
                {
                    Pessoa pessoa = new Pessoa()
                    {
                        PessoaCpf = pessoaView.PessoaCpf.Value,
                        Email = pessoaView.Email,
                        Idade = pessoaView.Idade.Value,
                        Nome = pessoaView.Nome,
                        CorCabelo = pessoaView.CorCabelo,
                        Gosto = pessoaView.Gosto,
                        Telefone = pessoaView.Telefone.Value
                    };

                    context.Pessoas.Add(pessoa);
                    context.SaveChanges();

                }
                return RedirectToAction("Retorno");
            }
            return View(pessoaView);
        }

        public ActionResult Retorno()
        {
            return View();
        }

    }
}