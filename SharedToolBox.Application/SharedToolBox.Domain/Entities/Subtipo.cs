using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Subtipo
    {
        public int Codigo { get; set; }

        public Tipo Tipo { get; set; }

        public string PathImagem { get; set; }

        public string Nome { get; set; }
    }
}