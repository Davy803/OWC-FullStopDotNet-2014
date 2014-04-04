using System.Web.Http;

namespace FullStopDotNet2014.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.ParameterBindingRules.Insert(0, SimplePostVariableParameterBinding.HookupParameterBinding);

            config.MapHttpAttributeRoutes();
        }
    }
}