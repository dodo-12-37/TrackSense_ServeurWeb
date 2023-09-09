using System.ComponentModel.DataAnnotations;

namespace TrackSense.API.Models
{
    public class SignInModel
    {
        [Required]
        public string UserLogin { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
}
