using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class UserViewModel
    {
        public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public AddressViewModel? Address { get; set; }
        public List<UserInterestPointViewModel>? InterestPoints { get; set; }
        public List<UserContactViewModel>? Contacts { get; set; }
        public List<UserTrackSenseViewModel>? TrackSenses { get; set; }
        public List<PlannedRideViewModel>? PlannedRides { get; set; }
        public List<CompletedRideViewModel>? CompletedRides { get; set; }

        public UserViewModel()
        {
            ;
        }

        public UserViewModel(User p_user)
        {
            this.UserLogin = p_user.UserLogin;
            this.UserFirstName = p_user.UserFirstName;
            this.UserLastName = p_user.UserLastName;
            this.UserPhoneNumber = p_user.UserPhoneNumber;

            if (p_user.Address != null)
            {
                this.Address = new AddressViewModel(p_user.Address);
            }

            if (p_user.IntersetPoints != null)
            {
                this.InterestPoints = p_user.IntersetPoints
                    .Select(point => new UserInterestPointViewModel(point))
                    .ToList();
            }

            if (p_user.Contacts != null)
            {
                this.Contacts = p_user.Contacts
                    .Select(contact => new UserContactViewModel(contact))
                    .ToList();
            }

            if (p_user.TrackSenses != null)
            {
                this.TrackSenses = p_user.TrackSenses
                    .Select(trackSense => new UserTrackSenseViewModel(trackSense))
                    .ToList();
            }

            if (p_user.PlannedRides != null)
            {
                this.PlannedRides = p_user.PlannedRides
                    .Select(ride => new PlannedRideViewModel(ride))
                    .ToList();
            }

            if (p_user.CompletedRides != null)
            {
                this.CompletedRides = p_user.CompletedRides
                    .Select(completedRide => new CompletedRideViewModel(completedRide))
                    .ToList();
            }
        }

        public User ToEntity()
        {
            return new User
            {
                UserLogin = this.UserLogin,
                UserFirstName = this.UserFirstName,
                UserLastName = this.UserLastName,
                UserPhoneNumber = this.UserPhoneNumber,
                Address = this.Address?.ToEntity(),
                IntersetPoints = this.InterestPoints?
                    .Select(point => point.ToEntity())
                    .ToList(),
                Contacts = this.Contacts?
                    .Select(contact => contact.ToEntity())
                    .ToList(),
                TrackSenses = this.TrackSenses?
                    .Select(trackSense => trackSense.ToEntity())
                    .ToList(),
                PlannedRides = this.PlannedRides?
                    .Select(ride => ride.ToEntity())
                    .ToList(),
                CompletedRides = this.CompletedRides?
                    .Select(completedRide => completedRide.ToEntity())
                    .ToList()
            };
        }
    }

}
