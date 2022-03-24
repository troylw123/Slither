using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Slither.Data;
using System.Security.Claims;
using Slither.Data.Reply;
using Microsoft.EntityFrameworkCore;
using Slither.Models.Reply;
using Slither.Data.Entities;

namespace Slither.Services.Reply
{
    public class ReplyService : IReplyServices
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public ReplyService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
        
            var validId = int.TryParse(value, out _userId);
            if(!validId)
                throw new Exception("Attempted to build ReplyService without User Id claim");

                _dbContext = dbContext;
        }
        public async Task<IEnumerable<ReplyListItems>> GetAllReplyListItemsAsync()
        {
            var reply = await _dbContext.Replies
                .Where(entity => entity.AuthorId == _userId)
                .Select(entity => new ReplyListItems
                {
                    Id = entity.Id,
                    Title = entity.Text,
                })
                .ToListAsync();

            return reply;
        }
        public async Task<bool> CreateReplyAsync(ReplyCreate request)
        {
            var replyEntity = new ReplyEntity
            {
                Text = request.Text,
                AuthorId = _userId
            };

            _dbContext.Replies.Add(replyEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}