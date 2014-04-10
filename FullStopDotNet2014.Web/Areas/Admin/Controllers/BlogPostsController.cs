using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Common.ExtensionMethods;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Services.Interfaces;
using FullStopDotNet2014.Web.Extensions;
using FullStopDotNet2014.Web.Resources;
using FullStopDotNet2014.Web.ViewModels.Account;
using FullStopDotNet2014.Web.ViewModels.Admin;

namespace FullStopDotNet2014.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("BlogPosts")]
    public class BlogPostsController : AdminControllerBase<IBlogPostService>
    {
        public BlogPostsController(ControllerCommon controllerCommon, IBlogPostService service)
            : base(controllerCommon, service)
        {
        }

        public async Task<ActionResult> Index()
        {
            var posts = await Service.GetAllBlogPostsAsync();
            return View(posts.Select(x => new BlogPostViewModel { UserName = x.User.UserName }.InjectFrom(x)));
        }
        [HttpGet]
        [Route("Edit/{postId}")]
        public async Task<ActionResult> Edit(int postId)
        {
            var post = await Service.GetBlogPostAsync(postId);
            return View(new BlogPostViewModel { UserName = post.User.UserName }.InjectFrom(post));
        }
        [HttpPost]
        [Route("Edit/{postId}")]
        public async Task<ActionResult> Edit(int postId, BlogPostViewModel postVm)
        {
            await Service.SaveBlogPost(postVm);

            return RedirectToAction("Edit", new {postId });
        }

        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            var post = await Service.CreateBlogPostAsync(User.Identity.Name);
            return RedirectToAction("Edit", new { postId = post.Id });
        }
    }
}