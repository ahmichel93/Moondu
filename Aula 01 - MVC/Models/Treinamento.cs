using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aula_01___MVC.Models
{
    public class Treinamento
    { 
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Vagas { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final  { get; set; }
        public string Local { get; set; }


    }
}