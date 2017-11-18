using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Cidade
    {
        public int Codigo { get; set; }

        public UF UF { get; set; }

        public string Nome { get; set; }
    }
}