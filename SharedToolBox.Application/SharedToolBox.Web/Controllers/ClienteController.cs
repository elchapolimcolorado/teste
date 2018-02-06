using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using SoftFramework.Core.Infra.Repositorios.Contracts;
//using SoftFramework.Core.Infra.UnidadeDeTrabalho;
using SoftFramework.Web.Controllers.Base;
using SoftFramework.Web.Models.MercadoLivre;

namespace SoftFramework.Web.Controllers
{
    public class ClienteController : BaseController
    {
        //private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        //private readonly IRepositorioCliente _repositorioCliente;

        //public ClienteController(IUnidadeDeTrabalho unidadeDeTrabalho, IRepositorioCliente repositorioCliente)
        //{
        //    _unidadeDeTrabalho = unidadeDeTrabalho;
        //    _repositorioCliente = repositorioCliente;
        //}

        //
        // GET: /Cliente/

        //public ActionResult MeusApps()
        //{
        //    //var itens =  _repositorioCliente.ObterTodosOnde(x => true,_unidadeDeTrabalho).ToList();
        //    using (var uow = _unidadeDeTrabalho.GetUow())
        //    {
        //        var cliente = _repositorioCliente.ObterPorId(1, uow);
        //        var model = new HomeModel
        //        {
        //            IdCliente = cliente.Id,
        //            RazaoSocial = cliente.RazaoSocial,
        //            Apps = cliente.MercadoLivreApps.Select(x => new AppsModel
        //            {
        //                AccessToken = x.AccessToken,
        //                DataExpiracao = x.DataExpiracao,
        //                AppId = x.AppId,
        //                Id = x.Id
        //            }).ToList()
        //        };

        //        return View(model);
        //    }
        //}

    }
}
