namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Aula_01___MVC.Models.Aula01DbCtx>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aula_01___MVC.Models.Aula01DbCtx context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var data1 = new Pessoa()
            {
                Email = "email@email.com",
                Idade = 21,
                Nome = "Alyson Michel",
                PessoaCpf = 1
            };
            context.Pessoas.AddOrUpdate(data1);
            context.SaveChanges();

            var prod = new Produto()
            {
                Id = 1,
                Nome = "Alyson Michel",
                Valor = 1,
                Quantidade = 1,
                EstaAtivo = true
            };
            context.Produtos.AddOrUpdate(prod);
            context.SaveChanges();
        }
    }
}
