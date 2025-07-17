using System.Security.Claims;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;
using Kosmoeye_Api.Application.DTOS.Artwork.Search;
using Kosmoeye_Api.Application.DTOS.Artwork.Update;
using Kosmoeye_Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;
        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArtworkCommand command)
        {
            var result = await _artworkService.CreateArtworkAsync(command);
            return CreatedAtAction(nameof(Create), new {id = result.Id}, result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artworks = await _artworkService.GetAllArtworksAsync();
            return Ok(artworks);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var artwork = await _artworkService.GetArtworkByIdAsync(id);

            if (artwork == null)
                return NotFound(new { message = "Artwork não encontrada." });

            return Ok(artwork);
        }
        
        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchArtworksQuery query)
        {
            var result = await _artworkService.SearchArtworksAsync(query);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateArtworkCommand command)
        {
            command.Id = id;
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            command.AuthorId = Guid.Parse(userId);

            var updatedArtwork = await _artworkService.UpdateArtworkAsync(command);
            return Ok(updatedArtwork);
        }

    }
}
