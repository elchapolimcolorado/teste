using SharedToolBox.Domain.Enum;

namespace SharedToolBox.Domain.Entities
{
    public class Composicao
    {
        public int Codigo { get; set; }

        public Condominio Condominio { get; set; }

        public Ferramenta Ferramenta { get; set; }

        public EnumCondicao Condicao { get; set; }

        public int QuantidadeDiasAluguelPadrao { get; set; }

        public int QuantidadeDisponivelAluguel { get; set; }

        public decimal ValorMultaDiariaAtraso { get; set; }
    }
}