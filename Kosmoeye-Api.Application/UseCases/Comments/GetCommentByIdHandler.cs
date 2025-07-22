using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Comment;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Comments
{
    public class GetCommentByIdHandler
    {
        private readonly ICommentRepository _commentRepository;
        public GetCommentByIdHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentResponse> Handle(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new KeyNotFoundException("Comentário não encontrado");

            return new CommentResponse
            {
                Id = comment.Id,
                Content = comment.Content,
                UserId = comment.UserId,
                ArtworkId = comment.ArtworkId,
                CreatedAt = comment.CreatedAt, 
            };
        }
    }
}
