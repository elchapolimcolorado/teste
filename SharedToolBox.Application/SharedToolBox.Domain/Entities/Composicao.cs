using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Composicao
    {
        public int Codigo { get; set; }

        public Condominio Condominio { get; set; }

        public Ferramenta Ferramenta { get; set; }

        public Condicao Condicao { get; set; }
    }
}