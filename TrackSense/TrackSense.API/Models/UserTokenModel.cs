using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class UserTokenViewModel
    {
        public string UserLogin { get; set; }
        public string Token { get; set; }

        public UserTokenViewModel()
        {
            ;
        }

        public UserTokenViewModel(UserToken p_userToken)
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
