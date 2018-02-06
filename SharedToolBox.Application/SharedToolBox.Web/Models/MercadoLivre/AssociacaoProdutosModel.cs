using System.Collections.Generic;
using System.Web.Mvc;

namespace SoftFramework.Web.Models.MercadoLivre
{
    public class AssociacaoProdutosModel
    {
        public AssociacaoProdutosModel()
        {
            Filhos = new List<AssociacaoProdutosItemModel>();
        }
        public bool IsEdicao { get; set; }
        public AssociacaoProdutosItemModel Pai { get; set; }
        public List<AssociacaoProdutosItemModel> Filhos { get; set; }
    }

    public class AssociacaoProdutosItemModel
    {
        public int IdMercadoLivreApplication { get; set; }
        public int Id { get; set; }
        public string UrlProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeVariacoes { get; set; }
        public string NomeConta { get; set; }
        public bool IsEdicao { get; set; }
    }

    public class AtualizarQuantidadeVariacaoModel
    {
        public string Id{ get; set; }
        public int Qtd { get; set; }
    }
}