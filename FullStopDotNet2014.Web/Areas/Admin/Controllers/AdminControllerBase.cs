using System.Web.Mvc;
using FullStopDotNet2014.Common.Utilities;
using FullStopDotNet2014.Web.Controllers;
using FullStopDotNet2014.Web.Resources;

namespace FullStopDotNet2014.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = RoleNames.EditContentRole)]
    public class AdminControllerBase : CommonControllerBase
    {
        protected AdminControllerBase(TextResourceValues textResourceValues) : base(textResourceValues)
        {
        }
    }
}