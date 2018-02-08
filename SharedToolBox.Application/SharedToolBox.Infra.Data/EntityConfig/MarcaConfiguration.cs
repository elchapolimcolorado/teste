using System.Data.Entity.ModelConfiguration;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Infra.Data.EntityConfig
{
    public class MarcaConfiguration : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguration()
        {
            HasKey(c => c.Codigo);

            Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(c => c.Imagem);
        }
    }
}
