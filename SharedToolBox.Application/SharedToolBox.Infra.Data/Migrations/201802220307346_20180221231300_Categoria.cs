namespace SharedToolBox.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180221231300_Categoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Imagem = c.String(maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataManipulacao = c.DateTime(nullable: false, precision: 0),
                        LoginManipulacao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categoria");
        }
    }
}
