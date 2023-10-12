namespace TrackSense.API.Entities
{
    public class Address
    {
        public int AddressId { get; set; } = 0;
        public Location? Location { get; set; }
        public string ?AppartmentNumber { get; set; }
        public string ?StreetNumber { get; set; }
        public string ?StreetName { get; set; }
        public string ?ZipCode { get; set; }
        public string ?City { get; set; }
        public string ?State { get; set; }
        public string ?Country { get; set; }
    }
}
