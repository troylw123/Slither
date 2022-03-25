using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slither.Data;
using Slither.Data.Entities;
using Slither.Models.Posts;

namespace Slither.Services.Posts
{
    public class PostService : IPostService
    {
        // private readonly int _postId;
        private readonly ApplicationDbContext _postContext;
        public PostService(ApplicationDbContext postContext)
        {
            _postContext = postContext;
        }
        public async Task<bool> CreatePostAsync(CreatePost model)
        {
            var entity = new PostEntity
            {
                PostTitle = model.PostTitle,
                PostText = model.PostText,
                AuthorId = model.AuthorId
            };

            _postContext.Posts.Add(entity);
            var numberOfChanges = await _postContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ListPosts>> GetAllPostsAsync()
        {
            var posts = await _postContext.Posts
            // .Where(entity => entity.PostId == _postId)
            .Select(entity => new ListPosts
            {
                PostId = entity.PostId,
                PostTitle = entity.PostTitle,
                PostText = entity.PostText
            })
            .ToListAsync();

            return (IEnumerable<ListPosts>)posts;
        }
    }
}