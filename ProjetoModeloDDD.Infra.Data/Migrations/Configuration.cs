using System.Data.Entity.Migrations;

namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoModeloDDD.Infra.Data.Context.ProjetoModeloContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjetoModeloDDD.Infra.Data.Context.ProjetoModeloContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
