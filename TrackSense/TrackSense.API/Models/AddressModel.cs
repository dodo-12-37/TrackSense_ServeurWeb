using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public LocationViewModel Location { get; set; }
        public string AppartmentNumber { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public AddressViewModel()
        {
            ;
        }

        public AddressViewModel(Address p_address)
        {
            this.AddressId = p_address.AddressId;
            this.Location = new LocationViewModel(p_address.Location);
            this.AppartmentNumber = p_address.AppartmentNumber;
            this.StreetNumber = p_address.StreetNumber;
            this.StreetName = p_address.StreetName;
            this.ZipCode = p_address.ZipCode;
            this.City = p_address.City;
            this.State = p_address.State;
            this.Country = p_address.Country;
        }

        public Address ToEntity()
        {
            return new Address
            {
                AddressId = this.AddressId,
                Location = this.Location.ToEntity(),
                AppartmentNumber = this.AppartmentNumber,
                StreetNumber = this.StreetNumber,
                StreetName = this.StreetName,
                ZipCode = this.ZipCode,
                City = this.City,
                State = this.State,
                Country = this.Country
            };
        }
    }

}
