namespace TrackSense.API.Entities
{
    public class User
    {
        public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhneNumber { get; set; }
        public Address? Address { get; set; }
        public List<IntersetPoint>? IntersetPoints { get; set; }
    }
}
