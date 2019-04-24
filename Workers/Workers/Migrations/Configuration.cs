namespace Workers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Workers.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Workers.Models.WorkersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Workers.Models.WorkersContext context)
        {
            context.Categorias.AddOrUpdate(x => x.Id,
                new Categoria() { Id = 1, Nome = "Jardinagem" },
                new Categoria() { Id = 2, Nome = "Reformas"},
                new Categoria() { Id = 3, Nome = "Pintura"}
                );

            context.Prestadors.AddOrUpdate(x => x.Id,
                new Prestador()
                {
                    Id = 1,
                    Nome = "Daniel",
                    Sobrenome = "Candido",
                    Email = "danielfelipec18@hotmail.com",
                    Cpf = "103.283.819-18",
                    Rg = "12.412.515-4",
                    Nascimento = "17/05/1996",
                    Senha = "123456",
                    CategoriaId = 1,
                });
        }
    }
}
