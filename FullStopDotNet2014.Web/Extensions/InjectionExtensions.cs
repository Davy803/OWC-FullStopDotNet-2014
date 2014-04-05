using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace FullStopDotNet2014.Web.Extensions
{
    public static class InjectionExtensions
    {
        public static T InjectFrom<T>(this T obj, params object[] sourceObjects)
        {
            return (T)StaticValueInjecter.InjectFrom(obj, sourceObjects);
        }
    }
}