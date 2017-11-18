using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Endereco
    {
        public int Codigo { get; set; }

        public Cidade Cidade { get; set; }
    }
}