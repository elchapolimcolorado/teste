using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFramework.Web.Models.Usuario
{
    public class NovaPessoaViewModel
    {
        public int idPessoa { get; set; }
        public string Nome { get; set; }
        public bool isAtiva { get; set; }
    }
}