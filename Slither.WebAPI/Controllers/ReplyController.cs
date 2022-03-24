using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Slither.Services.Reply;


namespace Slither.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyServices _replyService;
        public ReplyController(IReplyServices replyService)
        {
            _replyService = replyService;
        }
    }

    //GET api/Reply
    [HttpGet]
    public async Task<IActionResult> GetAllReply()
    {
        var reply = await _replyService.GetAllReplyAsync();
        return Ok(reply);
    }
}