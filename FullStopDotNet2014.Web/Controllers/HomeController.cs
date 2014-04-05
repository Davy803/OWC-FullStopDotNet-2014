using System.Web.Mvc;
using FullStopDotNet2014.Web.Resources;
using FullStopDotNet2014.Web.ViewModels;

namespace FullStopDotNet2014.Web.Controllers
{
    public class HomeController : CommonControllerBase
    {
        public HomeController(TextResources textResources) : base(textResources)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(new ViewModelBase(TextResources));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}