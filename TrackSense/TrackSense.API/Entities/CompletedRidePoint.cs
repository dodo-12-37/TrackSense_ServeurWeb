namespace TrackSense.API.Entities
{
    public class CompletedRidePoint
    {
        public string CompletedRideId { get; set; } = null!;
        public int LocationId {  get; set; } =0;
        public Location Location { get; set; } = null!;
        public int? RideStep { get; set; } = 0;
        public double? Temperature { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public CompletedRidePoint()
        {
            
        }
        public CompletedRidePoint(Location p_location,string p_id)
        {
            this.Location = p_location;
            this.LocationId = p_location.LocationId;
            this.CompletedRideId = p_id;
        }

    }
}
