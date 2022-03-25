using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slither.Models.Posts;
using Slither.Services.Posts;

namespace Slither.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createPostResult = await _postService.CreatePostAsync(model);
            if (createPostResult)
            {
                return Ok("Post was created");
            }

            return BadRequest("Post couldn't be created");
        }

        [HttpGet]
        public async Task<IActionResult> ListPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);

        }
    }
}