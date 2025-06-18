using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNoticiasCA.Domain.Entities
{
    class Usuario
    {
        public Guid Id {  get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Role { get; private set; } = "Admin";
        public DateTime DataCriacao { get; private set; }

        public Usuario(string nome, string email, string senhaHash, string role = "Admin")
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Role = role;
            DataCriacao = DateTime.UtcNow;
        }
    }
}
