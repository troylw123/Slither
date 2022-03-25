using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slither.Models.Posts;

namespace Slither.Services.Posts
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(CreatePost model);
        Task<IEnumerable<ListPosts>> GetAllPostsAsync();
        Task<bool> UpdatePostAsync(PostUpdate request);
        Task<bool> DeletePostAsync(int postId);
    }
}