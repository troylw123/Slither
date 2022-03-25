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
        // private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public ReplyService(ApplicationDbContext dbContext)
        {

                _dbContext = dbContext;
        }
        public async Task<IEnumerable<ReplyListItems>> GetAllReplyListItemsAsync()
        {
            var reply = await _dbContext.Replies
                // .Where(entity => entity.AuthorId == _userId)
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
                CommentId = request.CommentId,
                AuthorId = request.AuthorId
            };

            _dbContext.Replies.Add(replyEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        //Robin screwed up
    }
}