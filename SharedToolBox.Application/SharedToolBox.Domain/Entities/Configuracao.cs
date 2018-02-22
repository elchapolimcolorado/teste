using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Configuracao : EntityBase
    {
        public int Codigo { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}