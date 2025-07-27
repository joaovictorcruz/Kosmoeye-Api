using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Follow
{
    public class UserFollowInfoResponse
    {
        public int Followers { get; set; }
        public int Following { get; set; }
    }
}
