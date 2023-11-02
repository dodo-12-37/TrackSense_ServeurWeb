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
