using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("Tracksense")]
public class Tracksense
{
    [Key]
    public string TracksenseId { get; set; } = null!;

    public string? UserLogin { get; set; }

    public decimal? LastLatitude { get; set; }

    public decimal? LastLongitude { get; set; }

    public decimal? LastAltitude { get; set; }

    public DateTime? LastCommunication { get; set; }

    public bool? IsFallen { get; set; }

    public bool? IsStolen { get; set; }

    [ForeignKey(nameof(UserLogin))]
    public virtual User User { get; set; }= null!;
}
