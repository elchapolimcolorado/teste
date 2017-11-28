using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public class Condominio
    {
        public int Codigo { get; set; }

        public Endereco Endereco { get; set; }

        public Contato Contato { get; set; }

        public string Nome { get; set; }

        public int QuantidadeUnidades { get; set; }

        public Usuario Sindico { get; set; }

        public Usuario Zelador { get; set; }

        public Usuario UsuarioAdministrativo { get; set; }
    }
}