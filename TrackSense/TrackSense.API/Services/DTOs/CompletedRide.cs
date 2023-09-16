using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("CompletedRide")]
public class CompletedRide
{
    [Key]
    public string CompletedRideId { get; set; }

    public string UserLogin { get; set; }

    public string? PlannedRideId { get; set; }

    public virtual DTOs.CompletedRideStatistic? CompletedRideStatistic { get; set; }
   
    public virtual ICollection<DTOs.CompletedRidePoint> CompletedRidePoints { get; set; } = new List<DTOs.CompletedRidePoint>();
    
    
    [ForeignKey(nameof(UserLogin))]
    public virtual User User { get; set; }

    
    [ForeignKey(nameof(PlannedRideId))]
    public virtual PlannedRide PlannedRide { get; set; }

    public CompletedRide()
    {
        
    }
    public CompletedRide(Entities.CompletedRide p_completedRide)
    {
        if (p_completedRide==null)
        {
            throw new NullReferenceException(nameof(p_completedRide));
        }
        if (p_completedRide.UserLogin == null)
        {
            throw new NullReferenceException(nameof(p_completedRide.UserLogin));
        }
        if (p_completedRide.CompletedRideId==string.Empty)
        {
            throw new InvalidOperationException("Id du CompletedRide ne doit pas être null ni vide");
        }

        this.UserLogin = p_completedRide.UserLogin;
        this.CompletedRideId =p_completedRide.CompletedRideId;

        this.PlannedRideId = p_completedRide?.PlannedRide?.PlannedRideId;

        if (p_completedRide!.CompletedRidePoints != null)
        {
            this.CompletedRidePoints = p_completedRide.CompletedRidePoints
                                                        .Select(point => new DTOs.CompletedRidePoint(point))
                                                        .ToList();
        }

        if(p_completedRide.Statistics != null)
        {
            this.CompletedRideStatistic = new DTOs.CompletedRideStatistic(p_completedRide.Statistics);
        }

        else
        {
            this.CompletedRideStatistic = CalculateStatistic();
        }
       
    }

    public Entities.CompletedRide ToEntity()
    {
        return new Entities.CompletedRide
        {
            CompletedRideId = this.CompletedRideId,
            UserLogin = this.UserLogin,
            CompletedRidePoints = this.CompletedRidePoints.Select(p => p.ToEntity()).ToList(),
            
            Statistics = this.CompletedRideStatistic != null
                        ? this.CompletedRideStatistic.ToEntity()
                        : CalculateStatistic().ToEntity(),
        };
    }

    private DTOs.CompletedRideStatistic CalculateStatistic()
    {

        return new DTOs.CompletedRideStatistic()
        {

            CompletedRideId = this.CompletedRideId,

            AvgSpeed =this.CompletedRidePoints!.Select(c => c.Location.Speed).ToList().Average(),

            MaxSpeed = this.CompletedRidePoints!.Select(c=>c.Location.Speed).ToList().Max(),

            Duration = this.CompletedRidePoints!.Select(c=>c.Date).Max() - this.CompletedRidePoints!.Select(c => c.Date).Min()
        };
    }
}
