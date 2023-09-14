using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("PlannedRide")]
    public class PlannedRideDTO
    {
        [Key]
        public Guid PlannedRideId { get; set; }

        [MaxLength(100)]
        public string UserLogin { get; set; }

        public string? Name { get; set; }
        public bool ?IsFavorite { get; set; } = true;

        [ForeignKey("UserLogin")]
        public virtual UserDTO User { get; set; }

        public PlannedRideDTO()
        {
            
        }
        public PlannedRideDTO(PlannedRide p_plannedRide)
        {
            if (string.IsNullOrEmpty(p_plannedRide.UserLogin))
            {
                throw new ArgumentNullException(nameof(p_plannedRide.UserLogin));
            }
            if(p_plannedRide.PlannedRideId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(p_plannedRide.PlannedRideId));
            }
            this.PlannedRideId = p_plannedRide.PlannedRideId;
            this.UserLogin = p_plannedRide.UserLogin;
            this.Name = p_plannedRide.Name;
            this.IsFavorite = p_plannedRide.IsFavorite;
        }

        public PlannedRide ToEntity()
        {
            return new PlannedRide()
            {
                PlannedRideId = this.PlannedRideId,
                UserLogin = this.UserLogin,
                Name = this.Name,
                IsFavorite = this.IsFavorite,
            };
        }
    }
}
