using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class PlannedRidePoint
{
    public Guid PlannedRideId { get; set; }

    public int LocationId { get; set; }

    public int? RideStep { get; set; }

    public double? Temperature { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual PlannedRide PlannedRide { get; set; } = null!;
}
