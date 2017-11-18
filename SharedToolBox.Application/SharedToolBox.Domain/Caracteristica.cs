using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain
{
    public class Caracteristica
    {
        public int Codigo { get; set; }

        public string Valor { get; set; }

        public Entities.Ferramenta Ferramenta { get; set; }

        public Dominio Dominio { get; set; }
    }
}