using System;
using System.Web.Mvc;

namespace SoftFramework.Web.ModelBinders
{
    public class GuidModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var parameter = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            return Guid.Parse(parameter.AttemptedValue);
        }
    }
}