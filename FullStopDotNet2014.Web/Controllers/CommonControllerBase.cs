using System.Web.Mvc;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Web.Resources;
using FullStopDotNet2014.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;

namespace FullStopDotNet2014.Web.Controllers
{
    public class CommonControllerBase : Controller
    {
        protected CommonControllerBase(ControllerCommon controllerCommon)
        {
            TextResourceValues = controllerCommon.TextResourceValues;
            UserManager = controllerCommon.UserManager;
        }

        public UserManager<ApplicationUser> UserManager { get; set; }
        public TextResourceValues TextResourceValues { get; set; }
    }

    public class CommonControllerBase<TService> : CommonControllerBase
    {
        protected TService Service { get; private set; }

        public CommonControllerBase(ControllerCommon controllerCommon, TService service)
            : base(controllerCommon)
        {
            Service = service;
        }
    }
}