using System.Collections;
using System.Collections.Generic;

namespace SoftFramework.Web.Models.MercadoLivre
{
    public class AtualizarVariacaoListagemModel
    {
        public AtualizarVariacaoListagemModel()
        {
            Variacoes = new List<AtualizarVariacaoListagemItemModel>();
        }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }

        public IEnumerable<AtualizarVariacaoListagemItemModel> Variacoes { get; set; }    
    }

    public class AtualizarVariacaoListagemItemModel
    {
        public AtualizarVariacaoListagemItemModel()
        {
            Combinacoes = new List<AtualizarVariacaoCombinacaoModel>();
        }
        public int Id { get; set; }
        public string IdVariacaoMercadoLivre { get; set; }
        public double Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string CorPrincipal { get; set; }
        public string CorSecundaria { get; set; }
        public string Tamanho { get; set; }

        public int IndexTamanho
        {
            get
            {
                switch (Tamanho.ToUpper())
                {
                    case "PP":
                        return 0;
                    case "P":
                        return 1;
                    case "M":
                        return 2;
                    case "G":
                        return 3;
                    case "GG":
                        return 4;
                    case "XG":
                        return 5;
                    case "XXG":
                        return 6;
                    case "GGG":
                        return 7;
                    default:
                        return 10;
                }
            }
        }

        public IEnumerable<AtualizarVariacaoCombinacaoModel> Combinacoes { get; set; }
    }

    public class AtualizarVariacaoCombinacaoModel
    {
        public int Id { get; set; }
        public string IdCombinacao { get; set; }
        public string Nome { get; set; }
        public string ValorId { get; set; }
        public string ValorNome { get; set; }
    }
}