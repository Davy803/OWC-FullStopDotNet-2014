using System.Web.Mvc;
using FullStopDotNet2014.Web.Resources;

namespace FullStopDotNet2014.Web.Controllers
{
    public class CommonControllerBase : Controller
    {
        protected CommonControllerBase(TextResources textResources)
        {
            TextResources = textResources;
        }

        public TextResources TextResources { get; set; }
    }
}