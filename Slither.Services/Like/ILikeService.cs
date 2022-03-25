using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slither.Data.Entities;
using Slither.Models.Like;

namespace Slither.Services.Like
{
    public interface ILikeService
    {
        Task<bool> LikePostAsync(LikeEntity meLike);
        Task<IEnumerable<LikeDetail>> GetAllLikesAsync(int postId);
    }
}