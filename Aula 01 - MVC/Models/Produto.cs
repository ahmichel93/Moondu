using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models
{
    public class Produto
    {
        public int? Id { get; set; }

        public string Nome { get; set; }

        public int? Valor { get; set; }

        public int Quantidade { get; set; }

        public bool EstaAtivo { get; set; }
    }
}