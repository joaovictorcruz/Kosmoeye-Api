using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();  
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string? Bio { get; private set; }
        public string? PictureUrl{ get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();


        private User() { } //ef precisa de um construtor vazio
    
        
        public User(string username, string email, string passwordHash)
        {
            Username = username;
            Email = email;  
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;

        }
        public void UpdateUsername(string username)
        {
            Username = username;
        }

        public void UpdateProfile(string? bio, string? pictureUrl)
        {
            Bio = bio;
            PictureUrl = pictureUrl;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }
    }
}
