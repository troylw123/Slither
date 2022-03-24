using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Slither.Data;
using Slither.Data.Entities;

namespace Slither.Services.Like
{
    public class LikeService : ILikeService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public LikeService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build LikeService without User Id claim.");

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

        private Claim[] GetClaims(UserEntity user)
        {
            var fullName = $"{user.FirstName} {user.LastName}";
            var name = !string.IsNullOrWhiteSpace(fullName) ? fullName : user.Username;

            var claims = new Claim[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.Username),
                new Claim("Email", user.Email),
                new Claim("Name", name)
            };

            return claims;
        }
    }
}