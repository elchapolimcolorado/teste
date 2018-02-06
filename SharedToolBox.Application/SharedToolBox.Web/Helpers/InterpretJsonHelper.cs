using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SoftFramework.Web.Helpers
{
    public static class InterpretJsonHelper
    {
        public static HtmlString InterpretJson(this HtmlHelper helper, object model)
        {
            return (HtmlString)MvcHtmlString.Create(new JavaScriptSerializer().Serialize(model));
        }
    }
}