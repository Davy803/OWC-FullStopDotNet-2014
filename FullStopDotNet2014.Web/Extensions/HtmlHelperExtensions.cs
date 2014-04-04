using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Common.ExtensionMethods;

namespace FullStopDotNet2014.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string EditableClass<T>(this HtmlHelper<T> helper)
        {
            var isAdmin = helper.ViewContext.HttpContext.User.CanEditContent();
            return isAdmin ? "js-editable" : "";
        }
    }
}