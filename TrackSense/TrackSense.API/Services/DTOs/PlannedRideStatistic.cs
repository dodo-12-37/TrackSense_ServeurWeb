using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("PlannedRideStatistic")]
public class PlannedRideStatistic
{
    [Key]
    public string PlannedRideId { get; set; } = null!;

    public double? AverageSpeed { get; set; }

    public double? AverageDuration { get; set; }

    public double? MaximumSpeed { get; set; }

    public int? Falls { get; set; }

    public int? Calories { get; set; }

    public double? Distance { get; set; }
    
    public TimeSpan? Duration { get; set; }

    [ForeignKey(nameof(PlannedRideId))]
    public virtual PlannedRide PlannedRide { get; set; } = null!;
}
