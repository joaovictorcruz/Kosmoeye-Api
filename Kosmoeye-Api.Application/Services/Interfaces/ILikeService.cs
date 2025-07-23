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
    }
}
