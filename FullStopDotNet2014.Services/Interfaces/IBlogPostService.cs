using System.Collections.Generic;
using System.Threading.Tasks;
using FullStopDotNet2014.Common.ModelInterfaces;
using FullStopDotNet2014.Data.Models;

namespace FullStopDotNet2014.Services.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPost> GetBlogPostAsync(int postId);
        Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();
        Task<BlogPost> CreateBlogPostAsync(string userName);
        Task SaveBlogPost(IBlogPost blogPost);
    }
}