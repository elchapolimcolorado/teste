using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Emprestimo : EntityBase
    {
        public int Codigo { get; set; }

        public Usuario Usuario { get; set; }

        public Movimento Movimento { get; set; }

        public Condicao Condicao { get; set; }

        public Composicao Composicao { get; set; }
    }
}