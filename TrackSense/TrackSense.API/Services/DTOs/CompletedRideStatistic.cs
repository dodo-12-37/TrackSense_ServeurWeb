using System;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrackSense.API.Services.DTOs;
[Table("RideStatistic")]
[Keyless]
public class CompletedRideStatistic
{
    public string UserLogin { get; set; } = string.Empty!;
    public string CompletedRideId { get;  set; } = string.Empty!;
    public double? AvgSpeed { get;  set; }

    public double? MaxSpeed { get;  set; }

    public int? Falls { get;  set; }

    public int? Calories { get;  set; }

    public double? Distance { get;  set; }
    
    public TimeSpan Duration { get; set; }
    public virtual CompletedRide CompletedRide { get; set; }
    
    public CompletedRideStatistic()
    {
        
    }
   /* public CompletedRideStatistic(Entities.CompletedRideStatistics p_completedRideStatistics)
    {
        this.CompletedRideId = p_completedRideStatistics.CompletedRideId;
        this.MaxSpeed = p_completedRideStatistics.MaximumSpeed;
        this.AvgSpeed = p_completedRideStatistics.AverageSpeed;
        this.Falls = p_completedRideStatistics.Falls;
        this.Calories = p_completedRideStatistics.Calories;
        this.Distance = p_completedRideStatistics.Distance;
        this.Duration = p_completedRideStatistics.Duration;
        
    }*/
   
    public Entities.CompletedRideStatistics ToEntity()
    {
        var statistics = new Entities.CompletedRideStatistics();
        statistics.CompletedRideId = this.CompletedRideId;
        statistics.UserLogin = UserLogin;
        statistics.MaximumSpeed = MaxSpeed;
        statistics.AverageSpeed = AvgSpeed;
        statistics.Falls = Falls;
        statistics.Calories = Calories;
        statistics.Distance = Distance;
        statistics.Duration = Duration;

        return statistics;
       
    }
}
