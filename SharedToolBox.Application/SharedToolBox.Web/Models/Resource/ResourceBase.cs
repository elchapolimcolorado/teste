using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace SoftFramework.Web.Models.Resource
{
    public abstract class ResourceBase
    {
        public virtual string GetResource(string resourceName)
        {
            var fieldInfo = this.GetType().GetProperty(
                resourceName,
                BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.IgnoreCase);

            if (fieldInfo != null)
                return
                    (string)
                    fieldInfo.GetValue(this, null);

            return string.Empty;
        }
    }
}