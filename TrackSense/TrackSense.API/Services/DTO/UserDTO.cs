using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("user")]
    public class UserDTO
    {
        [Key][Required]
        public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int AddressId { get; set; }
        public string UserCodePostal { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
       
        public virtual AddressDTO AddressDTO { get; set; }
        public UserDTO()
        {
            ;
        }
/*
        public UserDTO(User p_user)
        {
            return new UserDTO();

            

          *//*  userDTO.UserAddress =p_user.Address;*/



            /*public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public Address? Address { get; set; }
        public List<UserInterestPoint>? IntersetPoints { get; set; }
        public List<UserContact>? Contacts { get; set; }
        public List<UserTrackSense>? TrackSenses { get; set; }
        public List<PlannedRide>? PlannedRides { get; set; }
        public List<CompletedRide>? CompletedRides { get; set; }*//*
        }
*/
        public User ToEntity()
        {
            return new User()
            {
                UserLogin = this.UserLogin,
                UserFirstName = this.UserFirstName,
                UserLastName = this.UserLastName,
                UserPhoneNumber = this.UserPhoneNumber,
                Address = this.AddressDTO.ToEntity(),
            };
        }
    }
}
