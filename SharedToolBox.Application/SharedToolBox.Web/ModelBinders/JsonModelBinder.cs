using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SoftFramework.Web.ModelBinders
{
    public class JsonModelBinder : DefaultModelBinder
    {


        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            if (!request.HttpMethod.Equals("POST") || !IsJsonRequest(request))
                return base.BindModel(controllerContext, bindingContext);

            using (var reader = new StreamReader(request.InputStream))
            {
                request.InputStream.Position = 0;
                var jsonStringData = reader.ReadToEnd();

                return
                    JsonConvert.DeserializeObject(
                        jsonStringData, bindingContext.ModelMetadata.ModelType);
            }
        }

        private static bool IsJsonRequest(HttpRequestBase request)
        {
            return request.AcceptTypes != null
                    && request.AcceptTypes.Contains("application/json");
        }
    }
}