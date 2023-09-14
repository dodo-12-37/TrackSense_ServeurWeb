using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class CompletedRidePoint
{
    public Guid CompletedRideId { get; set; }

    public int LocationId { get; set; }

    public int? RideStep { get; set; }

    public double? Temperature { get; set; }

    public DateTime Date { get; set; }

    public virtual CompletedRide CompletedRide { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
    public CompletedRidePoint()
    {
        
    }
    public CompletedRidePoint(Entities.CompletedRidePoint p_completedRidePoint)
    {
        if(p_completedRidePoint == null)
        {
            throw new ArgumentException(nameof(p_completedRidePoint));
        }

        this.CompletedRideId = p_completedRidePoint.CompletedRideId;
        this.CompletedRide.CompletedRideId = this.CompletedRideId;

        this.Location = new Location(p_completedRidePoint.Location);
        this.LocationId = this.Location.LocationId;
        this.RideStep = p_completedRidePoint.RideStep;
        this.Temperature = p_completedRidePoint.Temperature;
        this.Date = p_completedRidePoint.Date;

    }

    public Entities.CompletedRidePoint ToEntity()
    {
        return new Entities.CompletedRidePoint()
        {
            CompletedRideId = this.CompletedRideId,
            Location = this.Location.ToEntity(),
            Date = this.Date,
            RideStep = this.RideStep,
            Temperature = this.Temperature
        };
    }
}
