using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using MySql.Data.Entity;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Infra.Data.EntityConfig;

namespace SharedToolBox.Infra.Data.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext()
            : base("Server=localhost; Database=SharedToolBoxDB; Uid=root; Pwd=123456;")
        {
            
        }

        public DbSet<Categoria> Categoria { get; set; }
        //public DbSet<Tipo> Tipo { get; set; }
        //public DbSet<Subtipo> Subtipo { get; set; }
        //public DbSet<Marca> Marca { get; set; }
        //public DbSet<Ferramenta> Ferramenta { get; set; }
        //public DbSet<Caracteristica> Caracteristica { get; set; }
        //public DbSet<Dominio> Dominio { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Codigo")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<byte[]>()
                .Configure(p => p.HasColumnType("blob"));

            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            //modelBuilder.Configurations.Add(new TipoConfiguration());
            //modelBuilder.Configurations.Add(new SubtipoConfiguration());
            //modelBuilder.Configurations.Add(new MarcaConfiguration());
            //modelBuilder.Configurations.Add(new FerramentaConfiguration());
            //modelBuilder.Configurations.Add(new CaracteristicaConfiguration());
            //modelBuilder.Configurations.Add(new DominioConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataManipulacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataManipulacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataManipulacao").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
