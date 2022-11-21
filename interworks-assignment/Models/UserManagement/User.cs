using interworks_assignment.Models.Base;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace interworks_assignment.Models.UserManagement
{
    public class User : BaseEntity
    {
        public User() { 
        
        }

        public User(SignupDto signupDto) {
            this.Name=signupDto.Name;
            this.FirstName = signupDto.FirstName;
            this.LastName = signupDto.LastName;
            this.Email = signupDto.Email;
        }
        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;


        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public byte[] PasswordHash { get; set; } = new byte[0];

        public byte[] PasswordSalt { get; set; } = new byte[0];

        [NotMapped]
        public string RefreshToken { get; set; } = string.Empty;

        [NotMapped]
        public DateTime TokenCreated { get; set; }

        [NotMapped]
        public DateTime TokenExpires { get; set; }
    }
}
