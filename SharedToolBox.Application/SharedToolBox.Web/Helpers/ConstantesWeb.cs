using SoftFramework.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SoftFramework.Web.Helpers
{
    public static class ConstantesWeb
    {
        public static UsuarioLogado Usuario
        {
            get
            {
                var usuario = HttpContext.Current.Session["usuario"];
                if (usuario != null)
                    return (UsuarioLogado)usuario;
                return null;
            }
        }
    }
}