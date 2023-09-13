using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("user")]
    public class UserDTO
    {
        [Key]
        [MaxLength(100)]
        public string UserLogin { get; set; }

        public Guid? AddressId { get; set; }
        public string? UserLastName { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserEmail { get; set; }
        [MaxLength(12)]
        public string? UserCodePostal { get; set; }
        [MaxLength(12)]
        public string? UserPhoneNumber { get; set; }

        public AddressDTO? Address { get; set; }

        [ForeignKey("UserLogin")]
        public virtual CredentialDTO? Credential { get; set; }

        [ForeignKey("UserLogin")]
        public virtual UserTokenDTO? UserToken { get; set; }

 /*     public virtual List<ContactDTO> Contacts { get; set; }*/
        public virtual List<UserStatisticsDTO> ? UserStatistics { get; set; }
 /*     public virtual List<InterestPointDTO> InterestPoints { get; set; }*/
        public virtual List<CompletedRideDTO>? CompletedRides { get; set; }
        public UserDTO()
        {
            ;
        }

        public UserDTO(User p_user)
        {
            if(p_user == null)
            {
                throw new ArgumentNullException(nameof(p_user));
            }
            if (string.IsNullOrEmpty(p_user.UserLogin))
            {
                throw new NullReferenceException(nameof(p_user.UserLogin));
            }
            this.UserLogin = p_user.UserLogin;
            if (p_user.Address!=null)
            {
                this.Address = new AddressDTO(p_user.Address);
                this.AddressId = this.Address.AddressId;
            }
                this.UserEmail = p_user.UserEmail;

        }
        public User ToEntity()
        {
            return new User()
            {
                UserLogin = this.UserLogin,
                UserFirstName = this.UserFirstName,
                UserLastName = this.UserLastName,
                UserPhoneNumber = this.UserPhoneNumber,
                Address = this.Address?.ToEntity(),
            };
        }
    }
}
