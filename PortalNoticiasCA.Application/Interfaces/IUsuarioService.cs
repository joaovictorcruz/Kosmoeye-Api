using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalNoticiasCA.Application.DTOs;

namespace PortalNoticiasCA.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IUsuarioService> RegistrarUsuarioAsync(RegistrarUsuarioRequest request);   
    }
}
