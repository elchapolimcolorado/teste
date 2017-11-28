using SharedToolBox.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Ocorrencia
    {
        public int Codigo { get; set; }

        public Condominio Condominio { get; set; }

        public Usuario Usuario { get; set; }

        public EnumTipoOcorrencia TipoOcorrencia { get; set; }

        public Ferramenta Ferramenta { get; set; }

        public Composicao Composicao { get; set; }

        public string Observacao { get; set; }
    }
}