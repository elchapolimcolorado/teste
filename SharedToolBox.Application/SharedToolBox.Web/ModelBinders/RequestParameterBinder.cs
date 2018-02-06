using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SoftFramework.Web.ModelBinders
{
    public class RequestParameterBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var serializer = new JavaScriptSerializer();
            var parameter = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName);

            return serializer.Deserialize(parameter.AttemptedValue, bindingContext.ModelType);
        }
    }
}