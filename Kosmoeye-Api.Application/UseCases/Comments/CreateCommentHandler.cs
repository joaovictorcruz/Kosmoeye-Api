using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Comment;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Comments
{
    public class CreateCommentHandler
    {
        private readonly ICommentRepository _commentRepository;
        public CreateCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentResponse> Handle(CommentCommand commandHandler)
        {
            var comment = new Comment(commandHandler.UserId, commandHandler.ArtworkId, commandHandler.Content);
            await _commentRepository.AddAsync(comment);

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
