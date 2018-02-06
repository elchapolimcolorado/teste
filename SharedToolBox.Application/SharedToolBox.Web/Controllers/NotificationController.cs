using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SoftFramework.Web.Models.MercadoLivre;

namespace SoftFramework.Web.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
