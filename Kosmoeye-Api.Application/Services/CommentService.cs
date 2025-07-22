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
        private readonly CreateCommentHandler _createHandler;
        private readonly GetCommentByArtworkHandler _getCommentByArtworkHandler;
        public CommentService(CreateCommentHandler createHandler, GetCommentByArtworkHandler getCommentByArtworkHandler)
        {
            _createHandler = createHandler;
            _getCommentByArtworkHandler = getCommentByArtworkHandler;
        }

        public async Task<CommentResponse> CreateCommentAsync(CommentCommand command)
            => await _createHandler.Handle(command);
        public async Task<List<CommentResponse>> GetCommentsByArtworkAsync(Guid artworkId)
           => await _getCommentByArtworkHandler.Handle(artworkId);
    }
}
