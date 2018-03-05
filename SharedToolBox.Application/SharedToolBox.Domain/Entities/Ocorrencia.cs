using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Ocorrencia : EntityBase
    {
        public int Codigo { get; set; }

        public Condominio Condominio { get; set; }

        public Usuario Usuario { get; set; }

        public TipoOcorrencia TipoOcorrencia { get; set; }

        public Ferramenta Ferramenta { get; set; }

        public Composicao Composicao { get; set; }

        public byte[] Arquivo { get; set; }

        public string NomeArquivo { get; set; }

        public string ContentType { get; set; }
    }
}