using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("CompletedRide")]
    public class CompletedRideDTO
    {
        [Key]
        [Required]
        public Guid CompletedRideId { get; set; }

        [ForeignKey(nameof(UserLogin))]
        [Required]
        public string UserLogin { get; set; }=string.Empty;

        [ForeignKey(nameof(PlannedRideId))]
        public Guid? PlannedRideId { get; set; } = Guid.Empty;
        public virtual PlannedRideDTO? PlannedRide { get; set; } = null;
        public virtual List<CompletedRidePointDTO>? CompletedRidePoints { get; set; }
        public virtual CompletedRideStatisticsDTO Statistics { get; set; } = null;

        public CompletedRideDTO()
        {
            
        }

        public CompletedRideDTO(CompletedRide p_completedRide)
        {
            this.CompletedRideId = p_completedRide.CompletedRideId;
            this.UserLogin = p_completedRide.UserLogin;

            if(p_completedRide.PlannedRide != null)
            {
                this.PlannedRide = new PlannedRideDTO(p_completedRide.PlannedRide);
                this.PlannedRideId = this.PlannedRide.PlannedRideId;
            }
            
            this.CompletedRidePoints = p_completedRide.CompletedRidePoints?
                .Select(point => new CompletedRidePointDTO(point))
                .ToList();
            
            if (p_completedRide.Statistics!=null)
            {
                this.Statistics = new CompletedRideStatisticsDTO(p_completedRide.Statistics);
            };
            
        }

        public CompletedRide ToEntity(){
            return new CompletedRide{
                CompletedRideId = this.CompletedRideId,
                UserLogin = this.UserLogin,
                CompletedRidePoints = this.CompletedRidePoints?
                    .Select(point => point.ToEntity())
                    .ToList(),
                Statistics = this.Statistics.ToEntity()
            };
        }
    }
}
