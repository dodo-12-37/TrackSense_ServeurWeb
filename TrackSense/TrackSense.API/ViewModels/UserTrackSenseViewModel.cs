using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class UserTrackSenseViewModel
    {
        public int TrackSenseId { get; set; }
        public double LastLatitude { get; set; }
        public double LastLongitude { get; set; }
        public double LastAltitude { get; set; }
        public double LastSpeed { get; set; }
        public DateTime LastCommunication { get; set; }
        public bool IsFallen { get; set; }
        public bool IsStollen { get; set; }

        public UserTrackSenseViewModel()
        {
            ;
        }

        public UserTrackSenseViewModel(UserTrackSense p_userTrackSense)
        {
            this.TrackSenseId = p_userTrackSense.TrackSenseId;
            this.LastLatitude = p_userTrackSense.LastLatitude;
            this.LastLongitude = p_userTrackSense.LastLongitude;
            this.LastAltitude = p_userTrackSense.LastAltitude;
            this.LastSpeed = p_userTrackSense.LastSpeed;
            this.LastCommunication = p_userTrackSense.LastCommunication;
            this.IsFallen = p_userTrackSense.IsFallen;
            this.IsStollen = p_userTrackSense.IsStollen;
        }

        public UserTrackSense ToEntity()
        {
            return new UserTrackSense
            {
                TrackSenseId = this.TrackSenseId,
                LastLatitude = this.LastLatitude,
                LastLongitude = this.LastLongitude,
                LastAltitude = this.LastAltitude,
                LastSpeed = this.LastSpeed,
                LastCommunication = this.LastCommunication,
                IsFallen = this.IsFallen,
                IsStollen = this.IsStollen
            };
        }
    }

}
