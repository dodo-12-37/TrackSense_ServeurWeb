using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

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

        public bool CheckUserToken(string p_token)
        {
            if (String.IsNullOrWhiteSpace(p_token))
            {
                throw new ArgumentNullException($"{nameof(p_token)} ne doit pas etre null ou vide - {nameof(ManipulationUsers)}.{nameof(CheckUserToken)}");
            }

            return this.m_depotUsers.CheckUserToken(p_token);
        }

        public bool CheckUser(string p_userLogin)
        {
            return !String.IsNullOrEmpty(p_userLogin) 
                && this.m_depotUsers.GetUserByUserLogin(p_userLogin) != null;
        }

        public string GenerateUserBearerToken(string p_userLogin, string p_userPassword)
        {
            if (String.IsNullOrWhiteSpace(p_userLogin) || String.IsNullOrWhiteSpace(p_userLogin))
            {
                throw new ArgumentNullException($"{nameof(p_userLogin)} et {p_userLogin} ne doivent pas etre nulls ou vides - {nameof(ManipulationUsers)}.{nameof(GenerateUserBearerToken)}");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(p_userPassword));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, p_userLogin),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddYears(10), // Durée de validité du jeton
                signingCredentials: creds
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string bearerToken = tokenHandler.WriteToken(token);
            return bearerToken;
        }

        public IEnumerable<UserCompletedRide> GetCompletedRides(string p_userLogin)
        {
            if (string.IsNullOrWhiteSpace(p_userLogin) )
            {
                throw new ArgumentNullException($"{nameof(p_userLogin)} ne doit pas etre null ou vide - {nameof(ManipulationUsers)}.{nameof(GetCompletedRides)}");
            }

            IEnumerable<UserCompletedRide> completedRides = new List<UserCompletedRide>();

            if (this.m_depotUsers.GetUserByUserLogin(p_userLogin) != null)
            {
                completedRides = this.m_depotUsers.GetUserCompletedRides(p_userLogin);
            }

            return completedRides;
        }
    }
}
