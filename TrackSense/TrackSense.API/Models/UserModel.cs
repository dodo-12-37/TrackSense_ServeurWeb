using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class UserModel
    {
        public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public AddressModel? Address { get; set; }
        public List<UserInterestPointModel>? InterestPoints { get; set; }
        public List<UserContactModel>? Contacts { get; set; }
        public List<UserTrackSenseModel>? TrackSenses { get; set; }
        public List<PlannedRideModel>? PlannedRides { get; set; }
        public List<CompletedRideModel>? CompletedRides { get; set; }

        public UserModel()
        {
            ;
        }

        public UserModel(User p_user)
        {
            this.UserLogin = p_user.UserLogin;
            this.UserFirstName = p_user.UserFirstName;
            this.UserLastName = p_user.UserLastName;
            this.UserPhoneNumber = p_user.UserPhoneNumber;

            if (p_user.Address != null)
            {
                this.Address = new AddressModel(p_user.Address);
            }

            if (p_user.IntersetPoints != null)
            {
                this.InterestPoints = p_user.IntersetPoints
                    .Select(point => new UserInterestPointModel(point))
                    .ToList();
            }

            if (p_user.Contacts != null)
            {
                this.Contacts = p_user.Contacts
                    .Select(contact => new UserContactModel(contact))
                    .ToList();
            }

            if (p_user.TrackSenses != null)
            {
                this.TrackSenses = p_user.TrackSenses
                    .Select(trackSense => new UserTrackSenseModel(trackSense))
                    .ToList();
            }

            if (p_user.PlannedRides != null)
            {
                this.PlannedRides = p_user.PlannedRides
                    .Select(ride => new PlannedRideModel(ride))
                    .ToList();
            }

            if (p_user.CompletedRides != null)
            {
                this.CompletedRides = p_user.CompletedRides
                    .Select(completedRide => new CompletedRideModel(completedRide))
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
