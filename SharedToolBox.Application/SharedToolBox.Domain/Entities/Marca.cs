﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Marca : EntityBase
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public byte[] Imagem { get; set; }
        
        public string NomeArquivo { get; set; }

        public string ContentType { get; set; }
    }
}