using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Endereco
    {
        public int Codigo { get; set; }

        public Cidade Cidade { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string CEP { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string PontoReferencia { get; set; }
    }
}