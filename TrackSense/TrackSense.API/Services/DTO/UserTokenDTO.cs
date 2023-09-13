using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class UserTokenDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTokenId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserLogin { get; set; }

        [Required]
        [MaxLength(250)]
        public string Token { get; set; }

        public DateTime? LastUsedAt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserLogin")]
        public virtual UserDTO User { get; set; }
    }
}
