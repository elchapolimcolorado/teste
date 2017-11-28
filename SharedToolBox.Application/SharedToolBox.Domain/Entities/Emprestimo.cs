using SharedToolBox.Domain.Enum;
using System;

namespace SharedToolBox.Domain.Entities
{
    public class Emprestimo
    {
        public int Codigo { get; set; }

        public Usuario Usuario { get; set; }

        public EnumMovimento Movimento { get; set; }

        public EnumCondicao Condicao { get; set; }

        public Composicao Composicao { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataPrevistaDevolucao { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}