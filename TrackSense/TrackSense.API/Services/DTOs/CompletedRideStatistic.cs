using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;

public partial class CompletedRideStatistic
{
    public Guid CompletedRideId { get; private set; }

    public double? AvgSpeed { get; private set; }

    public double? MaxSpeed { get; private set; }

    public int? Falls { get; private set; }

    public int? Calories { get; private set; }

    public double? Distance { get; private set; }
    
    public TimeSpan? Duration { get; private set; }

    public virtual CompletedRide CompletedRide { get; set; } = null!;

    public CompletedRideStatistic()
    {
        
    }
    public CompletedRideStatistic(CompletedRide p_completedRide)
    {
        if (p_completedRide == null)
        {
            throw new ArgumentNullException(nameof(p_completedRide));
        }
        
        this.CompletedRide = p_completedRide;
        
        this.CompletedRideId = p_completedRide.CompletedRideId;
        
        this.AvgSpeed =p_completedRide.CompletedRidePoints.Average(p => p.Location.Speed);
        
        this.MaxSpeed = p_completedRide.CompletedRidePoints.Max(p => p.Location.Speed);
        
        this.Duration = p_completedRide.CompletedRidePoints.Max(p => p.Date) - p_completedRide.CompletedRidePoints.Min(p => p.Date);
    }

    public Entities.CompletedRideStatistics ToEntity()
    {
        return new Entities.CompletedRideStatistics()
        {
            AverageSpeed = this.AvgSpeed,
            MaximumSpeed = this.MaxSpeed,
            Duration = this.Duration,
            Calories = this.Calories,
            Falls = this.Calories

        };
    }
}
