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

            Property(c => c.NomeArquivo);

            Property(c => c.ContentType);

            HasRequired(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CodigoCategoria);
        }
    }
}
