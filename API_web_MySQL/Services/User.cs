using Microsoft.AspNetCore.Components.Web;

namespace API_web_MySQL.Services
{
    public class User
    {
        public int UserId { get;  set; } 
        public string UserName { get;  set; } 
        public string UserAddress { get;  set; } 
        public string UserCodePostal { get;  set; } 
        public string UserEmail { get;  set; }
        public User()
        {
            ;
        }
        /*public User(string p_userName, string p_userAddress, string  p_userCodePostal, string p_email,bool p_active)
        {
            UserName = p_userName;
            UserAddress = p_userAddress;
            UserCodePostal = p_userCodePostal;
            UserEmail = p_email;
        }*/
    }
}
