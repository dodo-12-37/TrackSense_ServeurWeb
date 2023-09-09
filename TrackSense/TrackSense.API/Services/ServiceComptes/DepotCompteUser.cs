using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrackSense.API.Entities.Interfaces;
using TrackSense.API.Models;
using TrackSense.API.Services.DTO;

namespace TrackSense.API.Services.ServiceComptes
{
    public class DepotCompteUser : IDepotCompteUser
    {
        private readonly UserManager<UserDTO> _userManager;
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly IConfiguration _configuration;

        public DepotCompteUser(UserManager<UserDTO>p_userManager,
                                SignInManager<UserDTO> p_signInManager,
                                IConfiguration p_configuration)
        {
            this._userManager = p_userManager;
            this._signInManager = p_signInManager;
            this._configuration = p_configuration;
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel p_model)
        {
            UserDTO userDTO = new UserDTO()
            {
                FirstName = p_model.FirstName,
                LastName = p_model.LastName,
                Email = p_model.Email,
                UserLogin = p_model.UserLogin,
                UserName = p_model.UserLogin,  
                
            };
            return await _userManager.CreateAsync(userDTO, p_model.Password);
        }
        public async Task<string> SignInAsync(SignInModel p_model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(p_model.UserLogin);
                if (user == null)
                {
                    return string.Format("le mot de passe ou le nom d'utilisateur est incorrect");
                }
                var result = await _signInManager.PasswordSignInAsync(p_model.UserLogin, p_model.Password, false, false);
                if (!result.Succeeded)
                {
                    return string.Format("le mot de passe ou le nom d'utilisateur est incorrect");
                }
                var authClaims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddYears(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                return e.Message;
            }
           
        }

    }
}
