﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Permissao
    {
        public Transacao Transacao { get; set; }

        public Funcionalidade Funcionalidade { get; set; }

        public Perfil Perfil { get; set; }

        public int Codigo { get; set; }

        public string Nome { get; set; }
    }
}