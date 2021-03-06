﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Ferramenta : EntityBase
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Subtipo Subtipo { get; set; }

        public int CodigoSubtipo { get; set; }

        public byte[] Imagem { get; set; }

        public string NomeArquivo { get; set; }

        public string ContentType { get; set; }

        public string ManualInstrucoes { get; set; }

        public string VideoExplicativo { get; set; }

        public Marca Marca { get; set; }

        public int CodigoMarca { get; set; }
    }
}