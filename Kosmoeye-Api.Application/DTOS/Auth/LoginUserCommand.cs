﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Auth
{
    public class LoginUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
