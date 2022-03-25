using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slither.Data.Entities;
using Slither.Services.Like;

namespace Slither.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> LikePost([FromBody] LikeEntity meLike)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if (await _likeService.LikePostAsync(meLike))
                return Ok("Added a 'like' to the post.");

            return BadRequest("Attempt failed. Please try again.");
        }
        [HttpGet("{postId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LikeEntity>), 200)]
        public async Task<IActionResult> GetLikesByPostId([FromRoute] int postId)
        {
            var likes = await _likeService.GetAllLikesAsync(postId);
            return likes is not null ? Ok(likes) : NotFound();
        }
    
    }
}