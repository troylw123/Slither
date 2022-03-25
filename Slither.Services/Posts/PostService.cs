using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly int _userId;
        public PostService(ApplicationDbContext postContext, IHttpContextAccessor httpContextAccessor)
        {
            _postContext = postContext;

            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build PostService without User Id claim");
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


        public async Task<bool> UpdatePostAsync(PostUpdate request)
        {
            var postEntity = await _postContext.Posts.FindAsync(request.PostId);

            if (postEntity?.AuthorId != _userId)
                return false;

            postEntity.PostTitle = request.PostTitle;
            postEntity.PostText = request.PostText;

            var numberOfChanges = await _postContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }


        public async Task<bool> DeletePostAsync(int postId)
        {
            var postEntity = await _postContext.Posts.FindAsync(postId);

            if (postEntity?.AuthorId != _userId)
                return false;

            _postContext.Posts.Remove(postEntity);
            return await _postContext.SaveChangesAsync() == 1;
        }
    }
}