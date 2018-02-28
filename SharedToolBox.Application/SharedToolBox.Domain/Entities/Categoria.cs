namespace SharedToolBox.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public byte Imagem { get; set; }
    }
}