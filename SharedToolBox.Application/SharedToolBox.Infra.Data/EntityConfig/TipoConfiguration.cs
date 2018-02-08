using System.Data.Entity.ModelConfiguration;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class TipoConfiguration : EntityTypeConfiguration<Tipo>
    {
        public TipoConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(c => c.Imagem);

            HasRequired(p => p.Categoria)
                    .WithMany()
                    .HasForeignKey(p => p.Categoria);
        }
    }
}
