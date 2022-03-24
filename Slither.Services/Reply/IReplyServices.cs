using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slither.Models.Reply;
using Slither.Data.Reply;

namespace Slither.Services.Reply
{
    public interface IReplyServices
    {
    Task<bool> CreateReplyAsync(ReplyCreate request);
    Task<IEnumerable<ReplyListItems>> GetAllReplyListItemsAsync();
    }
}
