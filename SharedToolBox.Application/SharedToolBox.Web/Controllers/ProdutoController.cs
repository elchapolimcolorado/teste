using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using AutoMapper;
using log4net.Repository.Hierarchy;
using SoftFramework.Web.Controllers.Base;
using SoftFramework.Web.Models.MercadoLivre;

namespace SoftFramework.Web.Controllers
{
    public class ProdutoController : Controller//BaseController
    {
        public ActionResult Index()
        {
            var prod = new ProdutoModel();

            prod.Itens.Add(new ProdutoItemModel()
            {
                Id = 1,
                Descricao = new Guid().ToString(),
                IdMercadoLivre = new Guid().ToString(),
                Nome = new Guid().ToString(),
                Quantidade = 10,
                QuantidadeProdutosRelacionados = 10
            });

            prod.Itens.Add(new ProdutoItemModel()
            {
                Id = 2,
                Descricao = new Guid().ToString(),
                IdMercadoLivre = new Guid().ToString(),
                Nome = new Guid().ToString(),
                Quantidade = 10,
                QuantidadeProdutosRelacionados = 10
            });

            return View(prod);
        }

        [HttpGet]
        public ActionResult AlterarQuantidade(int idProduto)
        {
            var produto = new ProdutoModel();

            produto.Itens.Add(new ProdutoItemModel()
            {
                Id = idProduto,
                Descricao = new Guid().ToString(),
                IdMercadoLivre = new Guid().ToString(),
                Nome = new Guid().ToString(),
                Quantidade = 10,
                QuantidadeProdutosRelacionados = 10
            });

            var model = new AtualizarVariacaoListagemModel
            {
                IdProduto = produto.Itens[0].Id,
                NomeProduto = produto.Itens[0].Nome//,
                //Variacoes = new AtualizarVariacaoListagemItemModel()
                //{
                //    Id = 1,
                //    IdVariacaoMercadoLivre = "1",
                //    Preco = 1,
                //    QuantidadeDisponivel = 1,
                //    CorPrincipal = "Laranja",
                //    CorSecundaria = "",
                //    Tamanho = ""
                //}
            };

            return View(model);
        }

        public ActionResult AssociacaoProdutos()
        {
            var model = new AssociacaoProdutosModel();

            return View(model);
        }
    }
}
