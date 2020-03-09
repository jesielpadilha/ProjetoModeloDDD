using System.Data.Entity.Migrations;

namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    public partial class AlterPropertyEntityCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "DataCadastro", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cliente", "DataCadasto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "DataCadasto", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cliente", "DataCadastro");
        }
    }
}
