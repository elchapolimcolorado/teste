using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Contato
    {
        public int Codigo { get; set; }

        public TipoContato TipoContato { get; set; }

        public string Valor { get; set; }

        public bool Preferencial { get; set; }

        public bool Ativo { get; set; }
    }
}