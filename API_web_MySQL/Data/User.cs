
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_web_MySQL.Data
{
    [Table("user")]
    public class User
    {
        [Key]
        public int UserId { get; set; } =0;
        public string UserName { get; set; } = string.Empty;
        public string UserAddress { get; set; } = string.Empty;
        public string UserCodePostal { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        /*public bool IsActive { get;set; } = false;*/

        public User()
        {
            
        }
        public User(Services.User p_user)
        {
            this.UserName = p_user.UserName;
            this.UserEmail = p_user.UserEmail;
            this.UserCodePostal = p_user.UserCodePostal;
            this.UserAddress = p_user.UserAddress;
        }
        public Services.User ToEntity()
        {
            return new Services.User()
            {
                UserId = this.UserId,
                UserName = this.UserName,
                UserAddress = this.UserAddress,
                UserCodePostal = this.UserCodePostal,
                UserEmail = this.UserEmail
            };
        }

    }
}
