using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public int Codigo { get; set; }

        public Perfil Perfil { get; set; }

        public Condominio Condominio { get; set; }

        public Contato Contato { get; set; }

        public byte[] Avatar { get; set; }

        public string NomeArquivo { get; set; }

        public string ContentType { get; set; }
    }
}