using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Common.ExtensionMethods;
using FullStopDotNet2014.Services.Interfaces;
using FullStopDotNet2014.Web.ViewModels.Account;
using FullStopDotNet2014.Web.ViewModels.Admin;

namespace FullStopDotNet2014.Web.Controllers
{
    public class BlogController : CommonControllerBase<IBlogPostService>
    {
        //
        // GET: /Blog/
        public BlogController(ControllerCommon controllerCommon, IBlogPostService service) : base(controllerCommon, service)
        {
        }

        public async Task<ViewResult> Index()
        {
            var posts = await Service.GetAllBlogPostsAsync();
            return View(posts.Select(x => new BlogPostViewModel {UserName = x.User.UserName}.InjectFrom(x)));
        }
	}
}