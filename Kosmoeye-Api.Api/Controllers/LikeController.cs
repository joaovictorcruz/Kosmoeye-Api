using System.Security.Claims;
using Kosmoeye_Api.Application.DTOS.Like;
using Kosmoeye_Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> Like([FromBody] LikeCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            command.UserId = Guid.Parse(userId!);
            var result = await _likeService.LikeAsync(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Unlike([FromBody] UnlikeCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            command.UserId = Guid.Parse(userId!);
            await _likeService.UnlikeAsync(command);
            return NoContent();
        }
    }
}
