using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("TrackSense")]
    public class TrackSenseDTO
    {
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
