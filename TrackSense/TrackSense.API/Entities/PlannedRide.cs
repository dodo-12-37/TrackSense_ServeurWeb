namespace TrackSense.API.Entities
{
    public class PlannedRide
    {
        public Guid PlannedRideId { get; set; } = Guid.NewGuid();
        public string UserLogin { get; set; } = string.Empty;
        public string? Name { get; set; } = null;
        public bool ?IsFavorite { get; set; } = null;
        public PlannedRideStatistics? Statistics { get; set; }=null;
        public ICollection<PlannedRidePoint> RidePoints { get; set; }

        public PlannedRide()
        {
            
        }
        public PlannedRide(string p_userLogin, ICollection<PlannedRidePoint> p_ridePoints)
        {
            if (string.IsNullOrEmpty(p_userLogin))
            {
                throw new ArgumentNullException(nameof(p_userLogin));
            }

            if(p_ridePoints.Count == 0)
            {
                throw new ArgumentException("La collection des points ne doit pas être vide");
            }

            this.UserLogin = p_userLogin;
            this.RidePoints = p_ridePoints;
        }
    }
}
