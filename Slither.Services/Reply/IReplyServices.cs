using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Slither.Models.Reply;

namespace Slither.Services.Reply
{
    public class IReplyServices
    {
        Task<IEmumerable<ReplyListItems>> GetAllReplyListItemsAsync()
        {
            var reply = await _dbContext.Reply
                .Where(entity => entity.OwnerId == _userId)
                .Select(entity => new ReplyListItems
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    CreatedUtc = entity.CreatedUtc
                })
                .ToListAsync();

            return reply;
        }
    }
}