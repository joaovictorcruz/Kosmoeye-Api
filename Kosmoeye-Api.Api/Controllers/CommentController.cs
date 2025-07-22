using System.Security.Claims;
using Kosmoeye_Api.Application.DTOS.Comment;
using Kosmoeye_Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentCommand command)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            command.UserId = Guid.Parse(userId);

            var createdComment = await _commentService.CreateCommentAsync(command);
            return Ok(createdComment);
        }

        [AllowAnonymous]
        [HttpGet("artwork/{artworkId}")]
        public async Task<IActionResult> GetByArtwork(Guid artworkId)
        {
            var comments = await _commentService.GetCommentsByArtworkAsync(artworkId);
            return Ok(comments);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            return Ok(comment);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            await _commentService.DeleteCommentAsync(id, Guid.Parse(userId));
            return NoContent();
        }
    }
}
