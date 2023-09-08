using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("user")]
    public class UserDTO
    {
        [Key]
        [MaxLength(50)]
        public string UserLogin { get; set; }
        [MaxLength(100)]
        public string ?FirstName { get; set; }
        [MaxLength(100)]
        public string ?LastName { get; set; }
        [ForeignKey("AddressId")]
        public int? AddressId { get; set; }
        [MaxLength(100)]
        public string? CodePostal { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(12)]
        public string? PhoneNumber { get; set; }

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
                UserFirstName = this.FirstName,
                UserLastName = this.LastName,
               /* UserPhoneNumber = this.PhoneNumber,*/
                Address = this.AddressDTO.ToEntity(),
            };
        }
    }
}
