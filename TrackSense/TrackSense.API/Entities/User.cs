namespace TrackSense.API.Entities
{
    public class User
    {
        public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public Address? Address { get; set; }
        public List<UserInterestPoint>? IntersetPoints { get; set; }
        public List<UserContact>? Contacts { get; set; }
        public List<UserTrackSense>? TrackSenses { get; set; }
        public List<PlannedRide>? PlannedRides { get; set; }
        public List<CompletedRide>? CompletedRides { get; set; }
    }
}
