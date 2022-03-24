using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Slither.Models.Reply;

namespace Slither.Services.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _DbContext;
        public ReplyService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
        
            var validId = int.TryParse(value, out _userId);
            if(!validId)
                throw new Exception("Attempted to build ReplyService without User Id claim");

                _DbContext = dbContext;
        }
    }
}