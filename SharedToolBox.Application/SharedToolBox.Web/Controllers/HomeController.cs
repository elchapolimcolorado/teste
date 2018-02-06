using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using AutoMapper;
//using SoftFramework.Core.Application;
//using SoftFramework.Core.Application.DTO.Notification;
//using SoftFramework.Core.Application.Servicos.Contratos;
//using SoftFramework.Core.Domain.Entidades.Modulos.MercadoLivre;
//using SoftFramework.Core.Infra.Repositorios.Contracts.Base;
//using SoftFramework.Core.Infra.UnidadeDeTrabalho;
//using SoftFramework.Core.Domain.Entidades;
//using SoftFramework.Core.Infra.Repositorios.Contracts;
using SoftFramework.Web.Controllers.Base;
using SoftFramework.Web.Helpers;
using SoftFramework.Web.Models.Base;
using SoftFramework.Web.Models.MercadoLivre;

namespace SoftFramework.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller//BaseController
    {
        //private readonly IRepositorioCliente _repositorioCliente;
        //private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        //private readonly IAuthenticationService _authenticationService;
        //private readonly INotificationService _notificationService;
        //private readonly IRepositorioUsuario _repositorioUsuario;
        //
        // GET: /Home/

        //public HomeController(IRepositorioCliente repositorioCliente, 
        //    IUnidadeDeTrabalho unidadeDeTrabalho,
        //    IAuthenticationService authenticationService,
        //    INotificationService notificationService)
        //{
        //    _repositorioCliente = repositorioCliente;
        //    _unidadeDeTrabalho = unidadeDeTrabalho;
        //    _authenticationService = authenticationService;
        //    _notificationService = notificationService;
        //}

        [HttpGet]
        public ActionResult Index()
        {
            //var user = UsuarioLogado;

            //using (var uow = _unidadeDeTrabalho.GetUow())
            //{
            //    var cliente = _repositorioCliente.ObterPorId(1, uow);
            var model = new HomeModel
            {
                IdCliente = 1,
                RazaoSocial = "Thiago",
            };

            return View(model);
            //}
        }

        //[HttpGet]
        //public ActionResult MLAuth()
        //{
        //    var paramsa = Request.QueryString;
        //    var code = paramsa["code"];
        //    //_authenticationService.ObterAccessTokenMercadoLivre(code);
        //   return RedirectToAction("MeusApps","Cliente");
        //}

        //[HttpGet]
        //public ActionResult MLAuthAccess()
        //{
        //    var paramsa = Request.QueryString;
        //    return null;
        //}

        //[HttpPost]
        //public JsonResult IndicarAppEmAutenticacao(IndicarAppEmAutenticacaoModel model)
        //{
        //    //_authenticationService.IndicarAppEmAutenticacao(model.idApp);
        //    return Json(new {success = true}, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult CallbackNotification(NotificationCallbackModel model)
        //{
        //    var dto = Mapper.Map<NotificationDto>(model);
        //    _notificationService.HandleNotification(dto);
        //    return Json(new {message = "tks"}, JsonRequestBehavior.AllowGet);
        //}

        //public void Logout()
        //{
        //    Session.Clear();
        //    FormsAuthentication.SignOut();

        //    Response.RedirectPermanent(FormsAuthentication.LoginUrl);
        //}
    }
}
