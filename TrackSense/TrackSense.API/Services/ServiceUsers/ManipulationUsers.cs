using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceUsers
{
    public class ManipulationUsers
    {
        private IDepotUsers m_depotUsers;

        public ManipulationUsers(IDepotUsers p_depotUsers)
        {
            if (p_depotUsers == null)
            {
                throw new ArgumentNullException();
            }

            this.m_depotUsers = p_depotUsers;
        }

        public bool CheckUserToken(string p_token, string p_userLogin)
        {
            if (String.IsNullOrWhiteSpace(p_token) || String.IsNullOrWhiteSpace(p_userLogin))
            {
                throw new ArgumentNullException($"{nameof(p_token)} et {p_userLogin} ne doivent pas etre nulls ou vides - ManipulationUsers.CheckUserToken");
            }

            UserToken userToken = new UserToken()
            {
                Token = p_token,
                UserLogin = p_userLogin
            };

            return this.m_depotUsers.CheckUserToken(userToken);
        }
        
    }
}
