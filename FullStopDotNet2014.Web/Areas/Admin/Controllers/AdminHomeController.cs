using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using System.Web.Security;
using FullStopDotNet2014.Common.Utilities;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Services.Implementation;
using FullStopDotNet2014.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;

namespace FullStopDotNet2014.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Home")]
    public class AdminHomeController : AdminControllerBase
    {
        
        private readonly IApplicationUserService _applicationUserService;

        public AdminHomeController(ControllerCommon controllerCommon, IApplicationUserService applicationUserService) : base(controllerCommon)
        {
            _applicationUserService = applicationUserService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult UserSelect()
        {
            var users = AsyncHelper.RunSync(() => _applicationUserService.GetUsersInRole(RoleNames.EditContentRole));
            return View(users);
        }
	}
}