using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStopDotNet2014.Data.Models;
using Microsoft.AspNet.Identity;

namespace FullStopDotNet2014.Services.Implementation
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
