using SharedToolBox.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Imagem);

            Property(c => c.NomeArquivo);

            Property(c => c.ContentType);
        }
    }
}
