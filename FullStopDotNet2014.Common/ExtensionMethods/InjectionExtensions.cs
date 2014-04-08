using Omu.ValueInjecter;

namespace FullStopDotNet2014.Common.ExtensionMethods
{
    public static class InjectionExtensions
    {
        public static T InjectFrom<T>(this T obj, params object[] sourceObjects)
        {
            return (T)StaticValueInjecter.InjectFrom(obj, sourceObjects);
        }
    }
}