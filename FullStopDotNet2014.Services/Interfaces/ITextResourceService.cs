using FullStopDotNet2014.Data.Models;

namespace FullStopDotNet2014.Services.Interfaces
{
    public interface ITextResourceService
    {
        TextResource GetTextResource(string name, string culture);
        void SaveTextResource(string name, string culture, string value);
    }
}