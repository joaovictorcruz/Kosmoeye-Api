using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Like;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface ILikeService
    {
        Task<LikeResponse> LikeAsync(LikeCommand command);
        Task UnlikeAsync(UnlikeCommand command);
        Task<int> GetLikeCountByArtworkAsync(Guid artworkId);
        Task<List<LikeResponse>> GetLikesByUserAsync(Guid userId);
        Task<bool> HasUserLikedAsync(Guid userId, Guid artworkId);
    }
}
