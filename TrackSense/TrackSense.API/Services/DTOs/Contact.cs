using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("Contact")]
public class Contact
{
    [Key]
    public int ContactId { get; set; }

    public string? UserLogin { get; set; }

    public string? Fullname { get; set; }

    public string? PhoneNumber { get; set; }
    
    [ForeignKey(nameof(UserLogin))]
    public virtual User? User { get; set; }
}
