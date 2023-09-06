using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class UserTokenModel
    {
        public string UserLogin { get; set; }
        public string Token { get; set; }

        public UserTokenModel()
        {
            ;
        }

        public UserTokenModel(UserToken p_userToken)
        {
            this.UserLogin = p_userToken.UserLogin;
            this.Token = p_userToken.Token;
        }

        public UserToken ToEntity()
        {
            return new UserToken
            {
                UserLogin = this.UserLogin,
                Token = this.Token
            };
        }
    }

}
