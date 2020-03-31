using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models
{
    public class Pessoa
    {
        [Key]
        public int PessoaCpf { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string CorCabelo { get; set; }
        public string Gosto { get; set; }
        public int Telefone { get; set; }
    }

}