using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models.ViewModel
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Valor { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é Obrigatório")]
        public int Quantidade { get; set; }

        [Display(Name = " Está Ativo?")]
        [Required(ErrorMessage = "O campo Está Ativo é Obrigatório")]
        public bool EstaAtivo { get; set; }
    }
}