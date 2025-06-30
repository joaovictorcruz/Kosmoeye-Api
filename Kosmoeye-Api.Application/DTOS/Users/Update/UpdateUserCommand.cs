using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Users.Update
{
    public class UpdateUserCommand
    {
        public Guid Id { get; set; } 
        public string Username { get; set; }
        public string? Bio { get; set; }
        public string? PictureUrl { get; set; }
    }
}
