namespace TrackSense.API.Entities
{
    public class PlannedRide
    {
        public string PlannedRideId { get; set; } = Guid.NewGuid().ToString();
        public string UserLogin { get; set; } = null!;
        public string? Name { get; set; } = null;
        public bool ?IsFavorite { get; set; } = null;
        public PlannedRideStatistics? Statistics { get; set; }=null;
        public ICollection<PlannedRidePoint> PlannedRidePoints { get; set; } = null!;

        public PlannedRide()
        {
            
        }
        public PlannedRide(string p_userLogin, ICollection<Location> p_locations)
        {
            if (string.IsNullOrEmpty(p_userLogin))
            {
                throw new ArgumentNullException(nameof(p_userLogin));
            }

            if(p_locations.Count == 0)
            {
                throw new ArgumentException("La collection des locations ne doit pas être vide");
            }

            this.PlannedRideId = Guid.NewGuid().ToString();
            this.UserLogin = p_userLogin;
            this.PlannedRidePoints = p_locations.Select(p => new PlannedRidePoint(p,this.PlannedRideId)).ToList();

        }
    }
}
