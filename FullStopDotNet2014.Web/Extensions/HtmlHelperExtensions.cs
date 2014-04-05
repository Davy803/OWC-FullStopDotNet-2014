using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Common.ExtensionMethods;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Web.Resources;

namespace FullStopDotNet2014.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string EditableClass<T>(this HtmlHelper<T> helper)
        {
            var isAdmin = helper.ViewContext.HttpContext.User.CanEditContent();
            return isAdmin ? "js-editable" : "";
        }
        public static string EditableData<T>(this HtmlHelper<T> helper, string url)
        {
            var isAdmin = helper.ViewContext.HttpContext.User.CanEditContent();

            return isAdmin ? string.Format("data-edit-url={0}", url) : "";
        }
    }
}