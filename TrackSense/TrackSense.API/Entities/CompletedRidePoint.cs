namespace TrackSense.API.Entities
{
    public class CompletedRidePoint
    {
        public Guid CompletedRideId { get; set; } = Guid.NewGuid();
        public Location Location { get; set; } = new Location();
        public int? RideStep { get; set; } = 0;
        public double? Temperature { get; set; } = 0;
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        public CompletedRidePoint()
        {
            
        }
        public CompletedRidePoint(Location p_location)
        {
            if (p_location == null)
            {
                throw new ArgumentNullException(nameof(p_location));
            }
            Location = p_location;
        }
    }
}
