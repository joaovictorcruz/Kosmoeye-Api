using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNoticiasCA.Application.DTOs
{
    public class RegistrarUsuarioRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Senha {  get; set; } = string.Empty;      
    }
}
