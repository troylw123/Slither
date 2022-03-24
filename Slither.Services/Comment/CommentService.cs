using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Slither.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly int _userId;
        public CommentService(IHttpContextAccessor AddHttpContextAccessor)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build CommentService without User Id claim.");
        }
    }
}