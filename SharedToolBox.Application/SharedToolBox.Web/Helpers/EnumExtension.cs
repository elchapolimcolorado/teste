using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftFramework.Web.Models.Resources;

namespace SoftFramework.Web.Helpers
{
    public static class EnumExtension
    {
        public static string GetEnumName(this object value)
        {
            return Enum.GetName(value.GetType(), value);
        }

        public static TEnum ToEnum<TEnum>(this string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        public static IEnumerable<SelectListItem> ToSelectList(this Enum enumeration)
        {
            return enumeration == null ? null : (from Enum d in Enum.GetValues(enumeration.GetType())
                                                 select new SelectListItem { 
                                                     Value = ((int)Enum.Parse(d.GetType(), d.ToString())).ToString(CultureInfo.InvariantCulture), 
                                                     Text = !String.IsNullOrEmpty(new PortalResource().GetResource(d.ToString())) 
                                                        ? new PortalResource().GetResource(d.ToString()) 
                                                        : d.ToString()});
        }
    }
}