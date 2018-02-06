using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Caracteristica
    {
        public int Codigo { get; set; }

        public string Valor { get; set; }

        public Ferramenta Ferramenta { get; set; }

        public Dominio Dominio { get; set; }
    }
}