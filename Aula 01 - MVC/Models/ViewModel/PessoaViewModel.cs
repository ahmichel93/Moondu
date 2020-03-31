using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models.ViewModel
{
    //public class ListagemPessoaViewModel
    //{
    //}

    public class PessoaViewModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Por favor, preenche os campos")]
        public int? PessoaCpf { get; set; }

        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Campo E-mail é obrigatório")]
        public string Email { get; set; }

        public int? Idade { get; set; }

        [Display(Name = "Cor do Cabelo")]
        public string CorCabelo { get; set; }

        public string Gosto { get; set; }


        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        public int? Telefone { get; set; }
    }
}