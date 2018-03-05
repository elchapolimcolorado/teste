using System.Data.Entity.ModelConfiguration;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class DominioConfiguration : EntityTypeConfiguration<Dominio>
    {
        public DominioConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Grupo)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(c => c.Chave)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(c => c.Valor)
                    .IsRequired()
                    .HasMaxLength(150);
        }
    }
}