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
        public Guid CompletedRideId { get; set; } = Guid.Empty;

        [MaxLength(100)]
        public string UserLogin { get; set; } = string.Empty;

        public Guid? PlannedRideId { get; set; } = Guid.Empty;

        [ForeignKey("UserLogin")]
        public virtual UserDTO User { get; set; }

        [ForeignKey(nameof(PlannedRideId))]
        public virtual PlannedRideDTO ?PlannedRide { get; set; }

        public virtual List<CompletedRidePointDTO> ?CompletedRidePoints { get; set; }

        public CompletedRideDTO()
        {
            
        }

        public CompletedRideDTO(CompletedRide p_completedRide)
        {
            if(p_completedRide.UserLogin == null)
            {
                throw new NullReferenceException(nameof(p_completedRide.UserLogin));
            }
            if (p_completedRide.CompletedRideId==Guid.Empty)
            {
                throw new InvalidOperationException("Id du CompletedRide ne doit pas être null ni vide");
            }
            this.UserLogin = p_completedRide.UserLogin;
            this.CompletedRideId =p_completedRide.CompletedRideId;

            if(p_completedRide.PlannedRide != null)
            {
                this.PlannedRide = new PlannedRideDTO(p_completedRide.PlannedRide);
                this.PlannedRideId = this.PlannedRide.PlannedRideId;
            }
            
            this.CompletedRidePoints = p_completedRide.CompletedRidePoints?
                .Select(point => new CompletedRidePointDTO(point))
                .ToList();
       /*     
            if (p_completedRide.Statistics!=null)
            {
                this.Statistics = new CompletedRideStatisticsDTO(p_completedRide.Statistics);
            };*/
            
        }

        public CompletedRide ToEntity(){
            return new CompletedRide{
                CompletedRideId = this.CompletedRideId,
                UserLogin = this.UserLogin,
                CompletedRidePoints = this.CompletedRidePoints?
                    .Select(point => point.ToEntity())
                    .ToList(),
               /* Statistics = this.Statistics.ToEntity()*/
            };
        }
    }
}
