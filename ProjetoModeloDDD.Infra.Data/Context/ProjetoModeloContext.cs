using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReplectedType.Name + "Id")
                .Configure(p => p.IsKey());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
