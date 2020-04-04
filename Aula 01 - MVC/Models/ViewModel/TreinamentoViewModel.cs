using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models.ViewModel
{

    public class TreinamentoListaViewModel
    {
        public List<Treinamento> ListaTreinamentos { get; set; }
    }

    public class TreinamentoViewModel
    {
        [Required]
        public int? Codigo { get; set; }

        [Required(ErrorMessage ="O Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe uma Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o Número de Vagas")]
        public int? Vagas { get; set; }

        [Required(ErrorMessage ="Por favor, informe uma data válida")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage ="Por favor, informe uma data válida")]
        public DateTime Final { get; set; }

        [Required(ErrorMessage = "O Local é Obrigatório")]
        public string Local { get; set; }
    }
}