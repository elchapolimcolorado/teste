using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Ferramenta
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Cor { get; set; }

        public Subtipo Subtipo { get; set; }

        public byte Imagem { get; set; }

        public string ManualInstrucoes { get; set; }

        public string VideoExplicativo { get; set; }

        public Marca Marca { get; set; }

        public string CaracteristicaTecnica { get; set; }

        public string ComposicaoMaterial { get; set; }

        public string Embalagem { get; set; }

        public string CodigoFornecedor { get; set; }

        public string EAN { get; set; }

        public string Acabamento { get; set; }

        public string Voltagem { get; set; }

        public string Alimentacao { get; set; }

        public string IndicacaoUso { get; set; }

        public string TipoEncaixe { get; set; }
    }
}