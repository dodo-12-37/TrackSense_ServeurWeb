using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;

[Table("ApplicationToken")]
public class ApplicationToken
{
    [Key]
    public int ApplicationTokenId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? LastUsedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
