using System.ComponentModel.DataAnnotations;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class CredentialDTO
    {
        [Key]
        [MaxLength(100)]
        public string UserLogin { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
