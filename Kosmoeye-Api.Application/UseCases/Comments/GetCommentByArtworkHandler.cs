using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Comment;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Comments
{
    public class GetCommentByArtworkHandler
    {
        private readonly ICommentRepository _commentRepository;
        public GetCommentByArtworkHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<List<CommentResponse>> Handle(Guid artworkId)
        {
            var comments = await _commentRepository.GetCommentByArtworkIdAsync(artworkId);

            return comments.Select(comments => new CommentResponse
            {
                Id = comments.Id,
                Content = comments.Content,
                UserId = comments.UserId,
                ArtworkId = comments.ArtworkId,
                CreatedAt = comments.CreatedAt,
            }).ToList();
        }
    }
}
