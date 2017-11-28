using SharedToolBox.Domain.Enum;
using System;

namespace SharedToolBox.Domain.Entities
{
    public class Usuario
    {
        public int Codigo { get; set; }

        public Perfil Perfil { get; set; }

        public Condominio Condominio { get; set; }

        public Contato Contato { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string HashSenha { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public EnumGenero Genero { get; set; }
    }
}