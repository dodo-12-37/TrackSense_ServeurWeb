using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("TrackSense")]
    public class TrackSenseDTO
    {
        [Key]
        [MaxLength(36)]
        public string TracksenseId { get; set; }

        [MaxLength(100)]
        public string UserLogin { get; set; }

        public decimal? LastLatitude { get; set; }
        public decimal? LastLongitude { get; set; }
        public decimal? LastAltitude { get; set; }
        public DateTime? LastCommunication { get; set; }
        public bool IsFallen { get; set; }
        public bool IsStolen { get; set; }

        [ForeignKey("UserLogin")]
        public virtual User User { get; set; }
        public TrackSenseDTO()
        {
            ;
        }

        public TrackSenseDTO(Entities.UserTrackSense p_trackSense)
        {
            throw new NotImplementedException();
        }

        public Entities.UserTrackSense ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
