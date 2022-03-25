using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Slither.Models.Comment;
using Slither.Data.Entities;
using Slither.Data;
using Microsoft.EntityFrameworkCore;

namespace Slither.Services.Comment
{
    public class CommentService : ICommentService
    {
        // private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CommentListItem>> GetAllCommentsAsync()
        {
                var comments = await _dbContext.Comments
                    // .Where(entity => entity.AuthorId == _userId)
                    .Select(entity => new CommentListItem
                    {
                        Id = entity.Id,
                        Comment = entity.Comment,
                        DateCreated = DateTime.Now
                    })
                    .ToListAsync();

                return comments;
            }
        

        public async Task<bool> CreateCommentAsync(CommentCreate request)
        {
            var commentEntity = new CommentEntity
            {
                Comment = request.Comment,
                DateCreated = DateTime.Now,
                AuthorId = request.AuthorId
            };
            _dbContext.Comments.Add(commentEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}