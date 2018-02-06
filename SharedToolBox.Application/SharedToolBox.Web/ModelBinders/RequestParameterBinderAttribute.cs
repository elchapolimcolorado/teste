using System;
using System.Web.Mvc;


namespace SoftFramework.Web.ModelBinders
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class RequestParameterBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new RequestParameterBinder();
        }
    }
}