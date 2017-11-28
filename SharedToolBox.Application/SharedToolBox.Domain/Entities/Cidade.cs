using SharedToolBox.Domain.Enum;

namespace SharedToolBox.Domain.Entities
{
    public class Cidade
    {
        public int Codigo { get; set; }

        public EnumUF UF { get; set; }

        public string Nome { get; set; }
    }
}