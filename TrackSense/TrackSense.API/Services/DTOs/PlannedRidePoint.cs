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
    public string PlannedRideId { get; set; } = string.Empty!;

    public int LocationId { get; set; } 

    public int? RideStep { get; set; }

    public double? Temperature { get; set; }

    [ForeignKey(nameof(LocationId))]
    public virtual Location Location { get; set; } = null!;

    [ForeignKey(nameof(PlannedRideId))]
    public virtual PlannedRide PlannedRide { get; set; } = null!;

    public PlannedRidePoint()
    {
        
    }

    public PlannedRidePoint(Entities.PlannedRidePoint p_plannedRidePoint)
    {
        this.PlannedRideId = p_plannedRidePoint.PlannedRideId;
        this.Location = new DTOs.Location(p_plannedRidePoint.Location);
        this.LocationId  = this.Location.LocationId;
        this.Temperature = p_plannedRidePoint.Temperature;
        this.RideStep = p_plannedRidePoint.RideStep;

    }
    public Entities.PlannedRidePoint ToEntity()
    {
        return new Entities.PlannedRidePoint()
        {
            PlannedRideId = this.PlannedRideId,
            Location = this.Location.ToEntity(),
            Temperature = this.Temperature,
            RideStep = this.RideStep
        };
    }
}
