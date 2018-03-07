using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SoftFramework.Web.Models.MercadoLivre
{
    public class HomeModel
    {
        public HomeModel()
        {
            Apps = new List<AppsModel>();
        }
        public int IdCliente { get; set; }
        public string RazaoSocial { get; set; }
        public IList<AppsModel> Apps { get; set; }
    }

    public class AppsModel
    {
        public string AccessToken { get; set; }
        public string AppId { get; set; }
        public int Id { get; set; }
        public DateTime? DataExpiracao { get; set; }

        public bool TokenExpirado
        {
            get
            {
                return !DataExpiracao.HasValue || DataExpiracao.Value < DateTime.Now;
            }
        }
    }

    public class IndicarAppEmAutenticacaoModel
    {
        public int idApp { get; set; }
    }
}