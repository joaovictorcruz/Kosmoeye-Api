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

        public CommentService(CreateCommentHandler createHandler)
        {
            _createHandler = createHandler;
        }

        public async Task<CommentResponse> CreateCommentAsync(CommentCommand command)
            => await _createHandler.Handle(command);
    }
}
