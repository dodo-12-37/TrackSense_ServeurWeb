using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("PlannedRidePoint")]
[PrimaryKey(nameof(PlannedRideId),nameof(LocationId))]
public class PlannedRidePoint
{
    public string PlannedRideId { get; set; } = null!;

    public int LocationId { get; set; }

    public int? RideStep { get; set; }

    public double? Temperature { get; set; }

    [ForeignKey(nameof(LocationId))]
    public virtual Location Location { get; set; } = null!;

    [ForeignKey(nameof(PlannedRideId))]
    public virtual PlannedRide PlannedRide { get; set; } = null!;
}
