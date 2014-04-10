using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FullStopDotNet2014.Common.ExtensionMethods;
using FullStopDotNet2014.Common.ModelInterfaces;
using FullStopDotNet2014.Data;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Services.Interfaces;

namespace FullStopDotNet2014.Services.Implementation
{
    public class BlogPostService : ServiceBase, IBlogPostService
    {
        public BlogPostService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BlogPost> GetBlogPostAsync(int postId)
        {
            return await DbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == postId);
        }
        public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
        {
            return await DbContext.BlogPosts.ToListAsync();
        }

        public async Task SaveBlogPost(IBlogPost blogPost)
        {
            var post = await DbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            post.InjectFrom(blogPost);
            await DbContext.SaveChangesAsync();
        }

        public async Task<BlogPost> CreateBlogPostAsync(string userName)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            var blogPost = new BlogPost { PublishDate = DateTime.Now, Header = "New Blog Post", User = user };
            DbContext.BlogPosts.Add(blogPost);
            await DbContext.SaveChangesAsync();
            return blogPost;
        }
    }
    public class ApplicationUserService : ServiceBase, IApplicationUserService
    {
        public ApplicationUserService(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<ApplicationUser>> GetUsersInRole(string roleName)
        {
            var role = await DbContext.Roles.FirstAsync(x => x.Name == roleName);
            return await DbContext.Users.Where(x => x.Roles.Any(r=>r.RoleId == role.Id)).ToListAsync();
        }
    }

    public interface IApplicationUserService
    {
        Task<List<ApplicationUser>> GetUsersInRole(string roleName);
    }
}