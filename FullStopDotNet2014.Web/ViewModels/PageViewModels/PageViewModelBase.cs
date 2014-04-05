using FullStopDotNet2014.Web.Resources;

namespace FullStopDotNet2014.Web.ViewModels.PageViewModels
{
    public class PageViewModelBase
    {
        public TextResourceValues TextResourceValues { get; set; }

        public PageViewModelBase(TextResourceValues textResourceValues)
        {
            TextResourceValues = textResourceValues;
        }
    }
}