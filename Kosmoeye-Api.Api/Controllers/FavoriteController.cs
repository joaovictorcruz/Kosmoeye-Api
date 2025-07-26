using System.Security.Claims;
using Kosmoeye_Api.Application.DTOS.FavoriteArtwork;
using Kosmoeye_Api.Application.DTOS.FavoriteArtworkResponse;
using Kosmoeye_Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddFavoriteCommand command)
        {
            command.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _favoriteService.AddFavoriteAsync(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveFavoriteCommand command)
        {
            command.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _favoriteService.RemoveFavoriteAsync(command);
            return NoContent();
        }
    }
}
