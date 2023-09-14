using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class UserStatistic
{
    public string UserLogin { get; set; } = null!;

    public double? AvgSpeed { get; set; }

    public double? MaxSpeed { get; set; }

    public DateTime? Duration { get; set; }

    public virtual User UserLoginNavigation { get; set; } = null!;
}
