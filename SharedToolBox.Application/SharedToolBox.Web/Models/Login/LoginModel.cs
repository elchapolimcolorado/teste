using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFramework.Web.Models.Login
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Message { get; set; }
        public string RememberMe { get; set; }
    }
}