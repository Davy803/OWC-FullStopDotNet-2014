using System.Web.Mvc;
using FullStopDotNet2014.Web.Resources;
using FullStopDotNet2014.Web.ViewModels;
using FullStopDotNet2014.Web.ViewModels.Account;
using FullStopDotNet2014.Web.ViewModels.PageViewModels;

namespace FullStopDotNet2014.Web.Controllers
{
    public class HomeController : CommonControllerBase
    {
        public HomeController(ControllerCommon controllerCommon) : base(controllerCommon)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(new PageViewModelBase(TextResourceValues));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}