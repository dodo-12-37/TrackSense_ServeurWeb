namespace API_web_MySQL.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserCodePostal { get; set; }
        public string UserEmail { get; set; }
        public UserModel()
        {

        }
        public UserModel(Services.User p_user)
        {
            UserId = p_user.UserId;
            UserName = p_user.UserName;
            UserAddress = p_user.UserAddress;
            UserCodePostal = p_user.UserCodePostal;
            UserEmail = p_user.UserEmail;
        }
    }
}
