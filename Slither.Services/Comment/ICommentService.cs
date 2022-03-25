using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slither.Models.Comment;

namespace Slither.Services.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CommentCreate request);
        Task<IEnumerable<CommentListItem>> GetAllCommentsAsync();

    }
}