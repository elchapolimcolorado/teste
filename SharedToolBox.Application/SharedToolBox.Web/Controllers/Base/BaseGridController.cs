using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftFramework.Web.Controllers.Base
{
    public class  BaseGridController : Controller
    {
        #region ::Propriedades::
        /// <summary>
        /// Obtém internamente o Campo para ordenação.
        /// </summary>
        protected string CampoOrdenacao
        {
            get
            {
                return ObterCampoOrdenacao(Request);
            }
        }

        /// <summary>
        /// Índice clicado ao paginar
        /// </summary>
        protected int IndicePaginacaoClicado
        {
            get
            {

                string indicePaginacaoAnterior = Request.Form["hdnPaginSelecionada"];
                string indicePaginacaoClicado = ObterIndicePaginacaoClicado(Request);
                if (indicePaginacaoClicado.Equals("<<"))
                {
                    return Convert.ToInt32(indicePaginacaoAnterior) - 1;
                }
                if (indicePaginacaoClicado.Equals(">>"))
                {
                    return Convert.ToInt32(indicePaginacaoAnterior) + 1;
                }

                return String.IsNullOrEmpty(ObterIndicePaginacaoClicado(Request)) ? 1 : Convert.ToInt32(ObterIndicePaginacaoClicado(Request));

            }
        }

        protected string FiltroAssociacao
        {
            get
            {
                return Request.Form["hdnFiltrarAssociados"];
            }
        }

        /// <summary>
        /// Obtém internamente a direção de ordenação.
        /// </summary>
        protected int DirecaoOrdenacao
        {
            get
            {
                return ObterDirecaoOrdenacao();
            }
        }

        /// <summary>
        /// Filtros de pesquisa, já formatados para a consulta ao banco.
        /// </summary>
        //protected Dictionary<string, string> FiltrosFormatados
        //{
        //    get
        //    {
        //        return ObterFiltrosFormatados();
        //    }
        //}

        protected bool IsDeletar
        {
            get
            {
                if (Request.Form["hdnDeletar"] != null)
                {
                    return ((Request.Form["hdnDeletar"].ToString()!=",") && !String.IsNullOrEmpty(Request.Form["hdnDeletar"].ToString()));
                }
                return false;
                
            }
        }

        protected List<int> IdsSelecionados
        {
            get
            {
                List<int> lista = new List<int>();
                if (Request["associado"] == null)
                {
                    return lista;
                }

                var array = Request["associado"].Split(',');

                foreach (var item in array)
                {
                    lista.Add(Convert.ToInt32(item));
                }
                return lista;
            }
        }

        protected List<int> TodosIdsGrid 
        {
            get 
            {
                if(Request["hdnIdsTodosItens"] == null)
                {
                    return null;
                }
                List<int> lista = new List<int>();
                var itens = Request["hdnIdsTodosItens"].Split(',');

                foreach (var item in itens)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        lista.Add(Convert.ToInt32(item));
                    }
                }
                return lista;
            }
        }

        /// <summary>
        /// Obtém todos os campos (header das colunas) do grid, informados na view. Exemplo.: idProjeto, Nome, DataInicio. 
        /// </summary>
        protected Dictionary<string, string> CamposDoGrid
        {
            get
            {
                return ObterCamposDoGrid(Request);
            }
        }

        /// <summary>
        /// Retorna os filtros, tipados de forma genérica. Exemplo: obj.Chave="IdProjeto"; obj.Valor = "5"; obj.Tipo="Int32";
        /// </summary>
        //protected List<GenericFilter> FiltrosTipados
        //{
        //    get
        //    {
        //        return ObterFiltrosTipado(Request);
        //    }
        //}

        #endregion

        #region ::Métodos Privados::

        /// <summary>
        /// Obtém os filtros formatados para a consulta no Banco (Ex.: int -> x = y; String -> x.Contains(y)) 
        /// </summary>
        /// <param name="requestCliente">Request da Action</param>
        /// <returns></returns>
        //private Dictionary<string, string> ObterFiltrosFormatados()
        //{
        //    List<GenericFilter> ListaFiltros = ObterFiltrosTipado(Request);
        //    return FormatarFiltros(ListaFiltros);
        //}

        /// <summary>
        /// Obtém os Filtros informados na view, ao solicitar o helper "GridPadrao"
        /// </summary>
        /// <param name="requestbase">Request da Action</param>
        /// <returns>Coleção dos campos do grid</returns>
        private static Dictionary<string, string> ObterCamposDoGrid(HttpRequestBase requestCliente)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();


            foreach (var item in requestCliente.Form.AllKeys)
            {
                if (item.Contains("$"))
                {
                    var Alias = item.Split('$')[0];
                    var Propriedade = item.Split('$')[1];
                    dict.Add(Alias, Propriedade);
                }
            }
            return dict;
        }


        /// <summary>
        /// Obtém os Filtros realizados nos campos de pesquisa, tipado genericamente
        /// </summary>
        /// <param name="requestCliente"></param>
        /// <returns>Lista de Filtros (Tipados) </returns>
        //private static List<GenericFilter> ObterFiltrosTipado(HttpRequestBase requestCliente)
        //{
        //    List<GenericFilter> ListaFiltros = new List<GenericFilter>();


        //    foreach (var item in requestCliente.Form.AllKeys)
        //    {
        //        if (item.Contains("|") && !String.IsNullOrEmpty(requestCliente[item]))
        //        {
        //            var Propriedade = item.Split('|')[0];
        //            var tipo = item.Split('|')[1];

        //            //GenericFilter gf = new GenericFilter();
        //            //gf.Chave = Propriedade;
        //            //gf.Tipo = tipo;
        //            //gf.Valor = requestCliente[item];
        //            //ListaFiltros.Add(gf);
        //        }
        //    }
        //    return ListaFiltros;
        //}


        /// <summary>
        /// Formata os filtros para a consulta no banco
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns>Coleção de Propriedades/Valor para a comparação na consulta ao banco</returns>
        //private Dictionary<string, string> FormatarFiltros(List<GenericFilter> Lista)
        //{
        //    Dictionary<string, string> listaRetorno = new Dictionary<string, string>();

        //    foreach (GenericFilter item in Lista)
        //    {
        //        int i = 0;

        //        if (item.Tipo.Equals("Int32"))
        //        {
        //            listaRetorno.Add(item.Chave + " = " + item.Valor, "");
        //        }
        //        if (item.Tipo.Equals("String"))
        //        {
        //            listaRetorno.Add(item.Chave + ".Contains(\"" + item.Valor + "\")", "");
        //        }
        //        if (item.Tipo.Equals("DateTime"))
        //        {
        //            listaRetorno.Add(item.Chave + "<=@" + i.ToString(), item.Valor);
        //            i++;
        //        }

        //    }
        //    return listaRetorno;
        //}

        /// <summary>
        /// Gera a Ordenação para os campos em qualquer grid
        /// </summary>
        /// <param name="campo"></param>
        /// <returns>Ordem do campo</returns>
        private int ObterDirecaoOrdenacao()
        {
            //Se não houver Ordenacao, ordenar ascending
            if (Session["Ordenacao"] == null || Session["Ordenacao"] == "")
            {
                if (!String.IsNullOrEmpty(CampoOrdenacao))
                {
                    Session["Ordenacao"] = new KeyValuePair<string, int>(CampoOrdenacao, 0);
                }
                return 0;
            }

            else
            {
                KeyValuePair<string, int> ord = (KeyValuePair<string, int>)Session["Ordenacao"];


                //Verifica se a ordenação anterior é do mesmo campo, se sim, inverte a ordem e retorna
                if (ord.Key == CampoOrdenacao)
                {
                    int novaOrdem = ord.Value == 0 ? 1 : 0;
                    KeyValuePair<string, int> novaOrdenacao = new KeyValuePair<string, int>(CampoOrdenacao, novaOrdem);
                    Session["Ordenacao"] = novaOrdenacao;
                    return novaOrdem;

                }

                Session["Ordenacao"] = new KeyValuePair<string, int>(CampoOrdenacao, 0);
                return 0;

            }



        }

        private string ObterCampoOrdenacao(HttpRequestBase RequestClient)
        {
            if (!String.IsNullOrEmpty(RequestClient.Form["hdnSort"]))
            {
                var campo = ObterCamposDoGrid(RequestClient).Where(x => x.Key.Equals(RequestClient.Form["hdnSort"].Split(',').FirstOrDefault())).FirstOrDefault();

                return campo.Value;
            }
            return string.Empty;
        }

        private string ObterIndicePaginacaoClicado(HttpRequestBase RequestClient)
        {
            if (!String.IsNullOrEmpty(RequestClient.Form["hdnPagin"]))
            {
                var campo = RequestClient.Form["hdnPagin"].Split(',').FirstOrDefault();

                return campo; ;
            }
            return string.Empty;
        }

        #endregion
    }
}