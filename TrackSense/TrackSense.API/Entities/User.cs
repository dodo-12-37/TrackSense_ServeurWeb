using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms.Ecc;
using System.ComponentModel.DataAnnotations;

namespace TrackSense.API.Entities
{
    public class User
    {
        public string UserLogin { get; set; } = string.Empty;
        public string ?UserFirstName { get; set; } = string.Empty;
        public string ?UserLastName { get; set; } = string.Empty;
        public string ?UserPhoneNumber { get; set; }
        public virtual Credential Credential { get; set; } = null!;
        public string UserEmail { get; set; } = string.Empty!;
        public Address? Address { get; set; }
        public List<UserToken>? Tokens { get; set; }
        public List<UserInterestPoint>? IntersetPoints { get; set; }
        public List<UserContact>? Contacts { get; set; }
        public List<UserTrackSense>? TrackSenses { get; set; }
        public List<PlannedRide>? PlannedRides { get; set; }
        public List<CompletedRide>? CompletedRides { get; set; }

    }
}
