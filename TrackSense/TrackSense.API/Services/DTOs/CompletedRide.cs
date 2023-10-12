using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("CompletedRide")]
public class CompletedRide
{
    [Key]
    public string CompletedRideId { get; set; }

    public string UserLogin { get; set; } = null!;

    public string? PlannedRideId { get; set; }
    [NotMapped]
    public virtual DTOs.CompletedRideStatistic? CompletedRideStatistic { get; set; }
   
    public virtual ICollection<DTOs.CompletedRidePoint> CompletedRidePoints { get; set; } = new List<DTOs.CompletedRidePoint>();
    
    [ForeignKey(nameof(UserLogin))]
    public virtual User User { get; set; }
    
    [ForeignKey(nameof(PlannedRideId))]
    public virtual PlannedRide ?PlannedRide { get; set; }    

    public CompletedRide()
    {
        
    }
    public CompletedRide(Entities.CompletedRide p_completedRide)
    {
        
        if (p_completedRide.CompletedRideId==string.Empty)
        {
            throw new InvalidOperationException("Id du CompletedRide ne doit pas être null ni vide");
        }

        this.UserLogin = p_completedRide.UserLogin;
        this.CompletedRideId =p_completedRide.CompletedRideId;
        if (p_completedRide.PlannedRide != null)
        {

            this.PlannedRideId = p_completedRide?.PlannedRide?.PlannedRideId;
            this.PlannedRide = new DTOs.PlannedRide(p_completedRide!.PlannedRide);
        }


        if (p_completedRide!.CompletedRidePoints != null)
        {
            this.CompletedRidePoints = p_completedRide.CompletedRidePoints
                                                        .Select(point => new DTOs.CompletedRidePoint(point))
                                                        .ToList();
        }

    }

    public Entities.CompletedRide ToEntity()
    {
        return new Entities.CompletedRide
        {
            CompletedRideId = this.CompletedRideId,
            UserLogin = this.UserLogin,
            CompletedRidePoints = this.CompletedRidePoints.Select(p => p.ToEntity()).ToList(),

            Statistics = this.CompletedRideStatistic?.ToEntity(),
                       
            PlannedRide = this.PlannedRide?.ToEntity()
        };
    }

  
}
