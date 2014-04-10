using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Web.Resources;
using Microsoft.AspNet.Identity;

namespace FullStopDotNet2014.Web.ViewModels.Account
{
    public class ControllerCommon
    {
        public ControllerCommon(UserManager<ApplicationUser> userManager, TextResourceValues textResourceValues)
        {
            UserManager = userManager;
            TextResourceValues = textResourceValues;
        }

        public UserManager<ApplicationUser> UserManager { get; set; }
        public TextResourceValues TextResourceValues { get; set; }
    }
}