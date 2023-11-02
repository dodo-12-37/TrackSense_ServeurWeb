using System.ComponentModel.DataAnnotations;

namespace TrackSense.API.Models
{
    public class SignUpModel
    {
        [Required]
        public string UserLogin { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
        
        [Required]
        public string PasswordConfirmed { get; set; } = null!;
        
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        public string FirstName { get; set; } = null!;
        
        [Required]
        public string LastName { get; set; } = null!;

    }
    
}
