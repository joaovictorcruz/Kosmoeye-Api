using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Comments
{
    public class DeleteCommentHandler
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(Guid id, Guid userId)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new KeyNotFoundException("Comentário não encontrado para exclusão.");

            if (comment.UserId != userId)
                throw new UnauthorizedAccessException("Você não tem permissão para excluir este comentário.");

            await _commentRepository.DeleteAsync(id);
        }
    }
}