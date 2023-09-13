using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class UserStatisticsDTO
    {
        [Key]
        [MaxLength(100)]
        public string UserLogin { get; set; }
        public double AvgSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public DateTime Duration { get; set; }

        [ForeignKey("UserLogin")]
        public virtual UserDTO User { get; set; }
    }
}
