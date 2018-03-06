using System.Data.Entity.ModelConfiguration;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class CaracteristicaConfiguration : EntityTypeConfiguration<Caracteristica>
    {
        public CaracteristicaConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Valor)
                    .IsRequired()
                    .HasMaxLength(1000);

            HasRequired(p => p.Ferramenta)
                    .WithMany()
                    .HasForeignKey(p => p.CodigoFerramenta);

            HasRequired(p => p.Dominio)
                    .WithMany()
                    .HasForeignKey(p => p.CodigoDominio);
        }
    }
}