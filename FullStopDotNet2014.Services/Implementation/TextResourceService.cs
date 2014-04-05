using System.Linq;
using FullStopDotNet2014.Data;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Services.Interfaces;
using Resources.Abstract;

namespace FullStopDotNet2014.Services.Implementation
{
    public class TextResourceService : ServiceBase, ITextResourceService
    {
        public TextResourceService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public TextResource GetTextResource(string name, string culture)
        {
            return DbContext.TextResources.FirstOrDefault(x => x.Name == name && x.Culture == culture);
        }
        public void SaveTextResource(string name, string culture, string value)
        {
            var resource = DbContext.TextResources.First(x => x.Name == name && x.Culture == culture);
            resource.Value= value;
            BaseResourceProvider.SetResourceCache(name, culture, value);
            DbContext.SaveChanges();
        }
    }
}