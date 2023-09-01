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

        public string GenerateUserBearerToken(string p_userLogin, string p_userPassword)
        {
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


    }
}
