using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;

public partial class PlannedRideStatistic
{
    public Guid PlannedRideId { get; set; }

    public double? AverageSpeed { get; set; }

    public double? AverageDuration { get; set; }

    public double? MaximumSpeed { get; set; }

    public int? Falls { get; set; }

    public int? Calories { get; set; }

    public double? Distance { get; set; }
    
    public DateTime? Duration { get; set; }

    public virtual PlannedRide PlannedRide { get; set; } = null!;
}
