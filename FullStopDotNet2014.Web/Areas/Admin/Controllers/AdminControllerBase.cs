using System.Web.Mvc;
using FullStopDotNet2014.Common.Utilities;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Web.Controllers;
using FullStopDotNet2014.Web.Resources;
using FullStopDotNet2014.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;

namespace FullStopDotNet2014.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = RoleNames.EditContentRole)]
    public class AdminControllerBase : CommonControllerBase
    {
        protected AdminControllerBase(ControllerCommon controllerCommon)
            : base(controllerCommon)
        {
        }

    }

    public class AdminControllerBase<TService> : AdminControllerBase
    {
        protected TService Service { get; private set; }

        public AdminControllerBase(ControllerCommon controllerCommon, TService service)
            : base(controllerCommon)
        {
            Service = service;
        }
    }
}