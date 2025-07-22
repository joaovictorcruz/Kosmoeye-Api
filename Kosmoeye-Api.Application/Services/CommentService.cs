using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Comment;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Comments;

namespace Kosmoeye_Api.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly CreateCommentHandler _createCommentHandler;
        private readonly GetCommentByArtworkHandler _getCommentByArtworkHandler;
        private readonly GetCommentByIdHandler _getCommentByIdHandler;
        private readonly DeleteCommentHandler _deleteCommentHandler;

        public CommentService(CreateCommentHandler createCommentHandler, GetCommentByArtworkHandler getCommentByArtworkHandler, 
            GetCommentByIdHandler getCommentByIdHandler, DeleteCommentHandler deleteCommentHandler)
        {
            _createCommentHandler = createCommentHandler;
            _getCommentByArtworkHandler = getCommentByArtworkHandler;
            _getCommentByIdHandler = getCommentByIdHandler;
            _deleteCommentHandler = deleteCommentHandler;
        }

        public async Task<CommentResponse> CreateCommentAsync(CommentCommand command)
            => await _createCommentHandler.Handle(command);
        public async Task<List<CommentResponse>> GetCommentsByArtworkAsync(Guid artworkId)
           => await _getCommentByArtworkHandler.Handle(artworkId);
        public async Task<CommentResponse> GetCommentByIdAsync(Guid id)
           => await _getCommentByIdHandler.Handle(id);

        public async Task DeleteCommentAsync(Guid id, Guid userId)
            => await _deleteCommentHandler.Handle(id, userId);
    }
}
