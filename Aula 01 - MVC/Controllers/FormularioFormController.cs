using Aula_01___MVC.Models;
using Aula_01___MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_01___MVC.Controllers
{
    public class FormularioFormController : Controller
    {
        // GET
        public ActionResult Index()
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            
            return View(produtoViewModel);
        }

        //POST
        [HttpPost]

        public ActionResult Index(ProdutoViewModel produtoView)
        {
            if (HttpContext.Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                using (Aula01DbCtx context = new Aula01DbCtx())
                {
                    Produto produto = new Produto()
                    {
                        Nome = produtoView.Nome,
                        Valor = produtoView.Valor,
                        Quantidade = produtoView.Quantidade,
                        EstaAtivo = produtoView.EstaAtivo
                    };

                    context.Produtos.Add(produto);
                    context.SaveChanges();

                }
                return RedirectToAction("Retorno");
            }
            return View(produtoView);
        }
        public ActionResult Retorno()
        {
            return View();
        }
    }
}