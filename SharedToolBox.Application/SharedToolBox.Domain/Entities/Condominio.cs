using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Condominio : EntityBase
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Contato Contato { get; set; }
    }
}