namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNascimentoNula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DataNascimento", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
