using System.Data.Entity.ModelConfiguration;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class FerramentaConfiguration : EntityTypeConfiguration<Ferramenta>
    {
        public FerramentaConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(c => c.Descricao)
                    .IsRequired()
                    .HasMaxLength(500);

            HasRequired(p => p.Subtipo)
                    .WithMany()
                    .HasForeignKey(p => p.CodigoSubtipo);

            Property(c => c.Imagem);

            Property(c => c.NomeArquivo);

            Property(c => c.ContentType);

            Property(c => c.ManualInstrucoes)
                    .HasMaxLength(200);

            Property(c => c.VideoExplicativo)
                    .HasMaxLength(200);

            HasRequired(p => p.Marca)
                    .WithMany()
                    .HasForeignKey(p => p.CodigoMarca);
        }
    }
}