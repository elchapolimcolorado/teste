using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace SoftFramework.Web.Models.MercadoLivre
{
    public class ProdutoModel
    {
        public ProdutoModel()
        {
            Itens = new List<ProdutoItemModel>();
        }
        public IList<ProdutoItemModel> Itens { get; set; }
    }

    public class ProdutoItemModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IdMercadoLivre { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeProdutosRelacionados { get; set; }
    }

    public class AtualizarProdutoRequestModel
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}