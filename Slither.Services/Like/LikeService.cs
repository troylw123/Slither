using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Slither.Data;
using Slither.Data.Entities;
using Slither.Models.Like;

namespace Slither.Services.Like
{
    public class LikeService : ILikeService
    {
        // private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public LikeService(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task<bool> LikePostAsync(LikeEntity meLike)
        {
            var likeEntity = new LikeEntity
            {
                PostId = meLike.PostId,
                AuthorId = meLike.AuthorId
            };
            _dbContext.Likes.Add(likeEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<LikeDetail>> GetAllLikesAsync(int postId)
        {
            var likes = await _dbContext.Likes
            .Where(entity => entity.PostId == postId)
            .Select(entity => new LikeDetail
            {
                Id = entity.Id,
                AuthorId = entity.AuthorId
            })
            .ToListAsync();
            return likes;
        }

    }
}