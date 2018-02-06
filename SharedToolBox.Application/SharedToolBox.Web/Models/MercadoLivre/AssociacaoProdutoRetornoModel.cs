using System.Collections.Generic;

namespace SoftFramework.Web.Models.MercadoLivre
{
    public class AssociacaoProdutoRetornoModel
    {
        public bool IsValid { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}