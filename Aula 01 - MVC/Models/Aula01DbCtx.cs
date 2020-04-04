using Aula_01___MVC.Models.ViewModel;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aula_01___MVC.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Aula01DbCtx : DbContext
    {
        // Classe associadas ao banco de dados

        public DbSet<Pessoa> Pessoas { get; set; }

        public Aula01DbCtx() : base("MySqlConn") { }
        
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Treinamento> Treinamentos { get; set; }

        public DbSet<Colaborador> Colaboradores { get; set; }

    }
}