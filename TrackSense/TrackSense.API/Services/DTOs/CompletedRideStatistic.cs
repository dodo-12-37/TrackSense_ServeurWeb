using System;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("CompletedRideStatistic")]
public class CompletedRideStatistic
{
    [Key]
    public string CompletedRideId { get;  set; } = null!;

    public double? AvgSpeed { get;  set; }

    public double? MaxSpeed { get;  set; }

    public int? Falls { get;  set; }

    public int? Calories { get;  set; }

    public double? Distance { get;  set; }
    
    public TimeSpan Duration { get; set; }
    
    [ForeignKey("CompletedRideId")]
    public virtual CompletedRide CompletedRide { get; set; } = null!;
    
    public CompletedRideStatistic()
    {
        
    }
    public CompletedRideStatistic(Entities.CompletedRideStatistics p_completedRideStatistics)
    {
        this.CompletedRideId = p_completedRideStatistics.CompletedRideId;
        this.MaxSpeed = p_completedRideStatistics.MaximumSpeed;
        this.AvgSpeed = p_completedRideStatistics.AverageSpeed;
        this.Falls = p_completedRideStatistics.Falls;
        this.Calories = p_completedRideStatistics.Calories;
        this.Distance = p_completedRideStatistics.Distance;
        this.Duration = p_completedRideStatistics.Duration;
        
    }
   

    public Entities.CompletedRideStatistics ToEntity()
    {
        return new Entities.CompletedRideStatistics()
        {
            CompletedRideId = this.CompletedRideId,
            AverageSpeed = this.AvgSpeed,
            MaximumSpeed = this.MaxSpeed,
            Duration = this.Duration,
            Calories = this.Calories,
            Falls = this.Calories

        };
    }
}
