using AutoMapper;
using Newtonsoft.Json;
//using SoftFramework.Core.Domain.ObjetosValor;
using SoftFramework.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using SoftFramework.Core.Application.Servicos;
//using SoftFramework.Core.Domain.Entidades;
//using SoftFramework.Core.Domain.Exceptions;
//using SoftFramework.Core.Infra.Repositorios.Contracts;
using SoftFramework.Web.Models.Base;

namespace SoftFramework.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected UsuarioLogado UsuarioLogado
        {
            get
            {
                if(User.Identity.IsAuthenticated)
                    return JsonConvert.DeserializeObject<UsuarioLogado>(((FormsIdentity)((HttpContext.User).Identity)).Ticket.UserData);
                return null;
            }
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(!filterContext.HttpContext.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();
            else
                ViewData["NomeUsuario"] = UsuarioLogado.Nome;

            base.OnAuthorization(filterContext);
        }

        public JsonResult Processar(Func<object> s)
        {
            try
            {
                var model = s.Invoke();
                return RetornarJson(true, model);
            }
            //catch (MessageException ex)
            //{
            //    return RetornarJson(false, new{messages = ex.Messages});
            //}
            catch (Exception ex)
            {
                //new EmailSender().EnviarEmailErro(ex);
                return RetornarJson(false, ex.Message);
            }
            
        }

        public JsonResult Processar<T>(Func<object> s)
        {
            try
            {
                var dto = s.Invoke();
                var model = Mapper.Map<T>(dto);
                return RetornarJson(true, model);
            }
            //catch (MessageException ex)
            //{
            //    return RetornarJson(false, new { messages = ex.Messages });
            //}
            catch (Exception ex)
            {
                //new EmailSender().EnviarEmailErro(ex);
                return RetornarJson(false, ex.Message);
            }

        }


        public JsonResult Processar(Action s)
        {
            try
            {
                s.Invoke();
                return RetornarJson(true, null);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
   
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //catch (MessageException ex)
            //{
            //    new EmailSender().EnviarEmailErro(ex);
            //    return RetornarJson(false, new { messages = ex.Messages });
            //}
        }

        public JsonResult RetornarJson(bool sucesso, object model)
        {
            return Json(new
            {
                success = sucesso,
                result = model
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
