using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slither.Data.Entities;

namespace Slither.Services.Like
{
    public interface ILikeService
    {
        Task<bool> LikePostAsync(LikeEntity meLike);
    }
}