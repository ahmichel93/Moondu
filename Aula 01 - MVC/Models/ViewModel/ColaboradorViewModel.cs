using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models.ViewModel
{
    public class ColaboradorViewModel
    {
        [Required(ErrorMessage = "A Matrícula é Obrigatória!")]
        public int? Matricula { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é Obrigatório")]
        public string Email { get; set; }


        public int? Telefone { get; set; }


        public bool Gestor { get; set; }

    }

}