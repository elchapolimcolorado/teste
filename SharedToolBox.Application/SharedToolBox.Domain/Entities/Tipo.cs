using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Tipo : EntityBase
    {
        public int Codigo { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }
    }
}