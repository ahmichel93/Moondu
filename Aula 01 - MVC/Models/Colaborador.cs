using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models
{
    public class Colaborador
    {
        [Key]
        //Informa para o bd não fazer nada de alto incremento nesse campo
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Matricula { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Telefone { get; set; }

        public bool Gestor { get; set; }

    }
}