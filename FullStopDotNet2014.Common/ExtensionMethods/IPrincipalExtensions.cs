using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FullStopDotNet2014.Common.Utilities;

namespace FullStopDotNet2014.Common.ExtensionMethods
{
    public static class PrincipalExtensions
    {
        public static bool CanEditContent(this IPrincipal user)
        {
            return user.IsInRole(RoleNames.EditContentRole);
        }
    }
}
