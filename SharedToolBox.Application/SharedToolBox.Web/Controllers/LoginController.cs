using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SoftFramework.Web.Controllers.Base;
using SoftFramework.Web.Models.Base;
using SoftFramework.Web.Models.Login;
using System.Web.Script.Serialization;

namespace SoftFramework.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //private readonly IRepositorioUsuario _repositorioUsuario;

        //public LoginController(
        //    IRepositorioUsuario repositorioUsuario)
        //{
        //    _repositorioUsuario = repositorioUsuario;
        //}
      
        //
        // GET: /Login/
        [Authorize]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult Index(LoginModel model)
        //{
            //var usuario = _repositorioUsuario.ObterPorLoginESenha(model.Login, model.Senha);
            //if (usuario == null)
            //{
            //    var modelRetorno = new LoginModel
            //    {
            //        Message = "Login e/ou senha inválidos.",
            //        Senha = model.Senha,
            //        Login = model.Login,
            //        RememberMe = model.RememberMe
            //    };
            //    return View(modelRetorno);
            //}

            //var usuarioLogado = new UsuarioLogado
            //{
            //   IdUsuario = usuario.Id,
            //    Nome = usuario.Nome,
            //    Login = usuario.Login,
            //    Email = usuario.Email,
            //    IdCliente = usuario.Cliente.Id
            //};

            //var userData = new JavaScriptSerializer().Serialize(usuarioLogado);

            //var ticket = new FormsAuthenticationTicket(
            //1,                                     // ticket version
            //usuarioLogado.Login,                   // authenticated username
            //DateTime.Now,                          // issueDate
            //DateTime.Now.AddMinutes(300),          // expiryDate
            //true,                                  // true to persist across browser sessions
            //userData,                              // can be used to store additional user data
            //FormsAuthentication.FormsCookiePath);  // the path for the cookie

            //// Encrypt the ticket using the machine key
            //string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            //// Add the cookie to the request to save it
            //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //cookie.HttpOnly = true;
            //Response.Cookies.Add(cookie);

            //return Redirect(FormsAuthentication.DefaultUrl);
        //}

        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();

            return Redirect(FormsAuthentication.LoginUrl);
        }

    }
}
