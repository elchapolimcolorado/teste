using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Subtipo
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public Tipo Tipo { get; set; }

        public int Imagem { get; set; }
    }
}