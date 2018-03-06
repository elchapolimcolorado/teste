using System.Data.Entity.ModelConfiguration;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class SubtipoConfiguration : EntityTypeConfiguration<Subtipo>
    {
        public SubtipoConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(c => c.Imagem);

            Property(c => c.NomeArquivo);

            Property(c => c.ContentType);

            HasRequired(p => p.Tipo)
                    .WithMany()
                    .HasForeignKey(p => p.CodigoTipo);
        }
    }
}
