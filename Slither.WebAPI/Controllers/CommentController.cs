using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slither.Services.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Slither.Models.Comment;

namespace Slither.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET api/Comment
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);

        }

        // POST api/Comment
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _commentService.CreateCommentAsync(request))
                return Ok("Comment created successfully.");

            return BadRequest("Comment could not be created.");
        }
    }
}