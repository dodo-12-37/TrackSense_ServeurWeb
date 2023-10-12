namespace TrackSense.API.Entities
{
    public class PlannedRidePoint
    {
        public string PlannedRideId { get;  set; } = string.Empty;
        public Location Location { get; set; } = null!;
        public int? RideStep { get; set; } = 0;
        public double? Temperature { get; set; } = 0;
        public PlannedRidePoint()
        {
            
        }

        public PlannedRidePoint(string plannedRideId, Location location, int? rideStep, double? temperature)
        {
            PlannedRideId=plannedRideId;
            Location=location;
            RideStep=rideStep;
            Temperature=temperature;
        }
        public PlannedRidePoint(Location p_location,string _id)
        {
            this.PlannedRideId = _id;   
            this.Location=p_location;
        }
    }
}
