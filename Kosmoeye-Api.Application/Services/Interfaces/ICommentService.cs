using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Comment;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentResponse> CreateCommentAsync(CommentCommand command);
        Task<List<CommentResponse>> GetCommentsByArtworkAsync(Guid artworkId);
    }
}
