using System.Web.Mvc;
using FullStopDotNet2014.Web.Resources;

namespace FullStopDotNet2014.Web.Controllers
{
    public class CommonControllerBase : Controller
    {
        protected CommonControllerBase(TextResourceValues textResourceValues)
        {
            TextResourceValues = textResourceValues;
        }

        public TextResourceValues TextResourceValues { get; set; }
    }
}