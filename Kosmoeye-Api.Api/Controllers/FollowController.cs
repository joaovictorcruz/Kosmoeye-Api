using System.Security.Claims;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost]
        public async Task<IActionResult> Follow([FromBody] FollowUserCommand command)
        {
            command.FollowerId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _followService.FollowAsync(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Unfollow([FromBody] UnfollowUserCommand command)
        {
            command.FollowerId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _followService.UnfollowAsync(command);
            return NoContent();
        }
    }
}
