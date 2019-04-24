namespace Workers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prestadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(),
                        Email = c.String(),
                        Cpf = c.String(),
                        Rg = c.String(),
                        Nascimento = c.String(),
                        Senha = c.String(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prestadors", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Prestadors", new[] { "CategoriaId" });
            DropTable("dbo.Prestadors");
            DropTable("dbo.Categorias");
        }
    }
}
