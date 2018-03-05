using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public int Codigo { get; set; }

        public int TipoLogradouro { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Cidade Cidade { get; set; }
    }
}