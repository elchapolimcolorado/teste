using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    /// <summary>
    /// Configurações referente ao sistema
    /// </summary>
    public class Configuracao
    {
        public int Codigo { get; set; }
        
        public string Chave { get; set; }

        public string Valor { get; set; }
    }
}