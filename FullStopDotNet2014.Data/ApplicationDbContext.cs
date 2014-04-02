using FullStopDotNet2014.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FullStopDotNet2014.Data
{
    /// <summary>
    /// DbContext generated by template that supplies authentication models
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}