namespace TrackSense.API.Entities
{
    public class CompletedRide
    {
        public string CompletedRideId { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public PlannedRide? PlannedRide { get; set; }
        public List<CompletedRidePoint> CompletedRidePoints { get; set; } = null!;
        public CompletedRideStatistics ?Statistics { get; set; }

        public CompletedRide()
        {
            
        }
        public CompletedRide(string p_userLogin, List<Location> p_locations)
        {
            this.UserLogin = p_userLogin;
            
            this.CompletedRideId = Guid.NewGuid().ToString();
            
            this.CompletedRidePoints = p_locations.Select(l => new CompletedRidePoint(l,this.CompletedRideId)).ToList();
           
            this.Statistics = new CompletedRideStatistics(this.CompletedRidePoints,this.CompletedRideId);
        }
        public CompletedRide(string p_userLogin, List<Location> p_locations,PlannedRide p_plannedRide):this(p_userLogin,p_locations)
        {
            this.PlannedRide = p_plannedRide;
        }
    }
}
