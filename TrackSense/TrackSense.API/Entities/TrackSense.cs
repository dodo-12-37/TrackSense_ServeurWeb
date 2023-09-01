namespace TrackSense.API.Entities
{
    public class TrackSense
    {
        public int TrackSenseId { get; set; }
        public double LastLatitude { get; set; }
        public double LastLongitude { get; set; }
        public double LastAltitude { get; set; }
        public double LastSpeed { get; set; }
        public DateTime LastCommunication { get; set; }
        public bool IsFallen { get; set; }
        public bool IsStollen { get; set; }
    }
}
