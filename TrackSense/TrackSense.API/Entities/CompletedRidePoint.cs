namespace TrackSense.API.Entities
{
    public class CompletedRidePoint
    {
        public string CompletedRideId { get; set; } = null!;
        public Location Location { get; set; } = new Location();
        public int? RideStep { get; set; } = 0;
        public double? Temperature { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public CompletedRidePoint()
        {
            
        }
        public CompletedRidePoint(Entities.Location p_location)
        {
            if (p_location == null)
            {
                throw new ArgumentNullException(nameof(p_location));
            }
            Location = p_location;
        }
    }
}
