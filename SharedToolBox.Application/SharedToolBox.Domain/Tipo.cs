using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Tipo
    {
        public int Codigo { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public int Imagem { get; set; }
    }
}