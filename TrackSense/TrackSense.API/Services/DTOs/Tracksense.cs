using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class Tracksense
{
    public Guid TracksenseId { get; set; }

    public string? UserLogin { get; set; }

    public decimal? LastLatitude { get; set; }

    public decimal? LastLongitude { get; set; }

    public decimal? LastAltitude { get; set; }

    public DateTime? LastCommunication { get; set; }

    public bool? IsFallen { get; set; }

    public bool? IsStolen { get; set; }

    public virtual User? UserLoginNavigation { get; set; }
}
