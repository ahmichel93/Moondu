using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_01___MVC.Models
{
    public class Treinamento
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Vagas { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final  { get; set; }
        public string Local { get; set; }


    }
}