using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("user")]
    public class UserDTO
    {
        public string UserLogin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserAddress { get; set; }
        public string UserCodePostal { get; set; }
        public string UserEmail { get; set; }
        public UserDTO()
        {
            ;
        }

        public UserDTO(User p_user)
        {
            throw new NotImplementedException();
        }

        public User ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
