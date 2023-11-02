using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackSense.API.Services.DTOs;
[Table("UserStatistic")]
public partial class UserStatistic
{
    [Key]
    public string UserLogin { get; set; } = null!;

    public double? AvgSpeed { get; set; }

    public double? MaxSpeed { get; set; }

    public TimeSpan? Duration { get; set; }

    [ForeignKey(nameof(UserLogin))]
    public virtual User User { get; set; } = null!;
}
