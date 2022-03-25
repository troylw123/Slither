using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Slither.Services.Reply;
using Slither.Data;
using Slither.Data.Entities;
using Slither.Models.Reply;

namespace Slither.WebAPI.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
            private readonly IReplyServices _replyService;
            public ReplyController(IReplyServices replyService)
            {
                _replyService = replyService;
            }
    

        //GET api/Reply
        [HttpGet]
        public async Task<IActionResult> GetAllReply()
        {
            var reply = await _replyService.GetAllReplyListItemsAsync();
            return Ok(reply);
        }
        //Post api/Reply
        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] ReplyCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _replyService.CreateReplyAsync(request))
                return Ok("Reply created successfully");

            return BadRequest("Reply could not be created");
        }
    }
}