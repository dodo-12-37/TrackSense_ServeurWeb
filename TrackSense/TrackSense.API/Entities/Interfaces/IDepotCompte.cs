using Microsoft.AspNetCore.Identity;
using TrackSense.API.Models;

namespace TrackSense.API.Entities.Interfaces
{
    public interface IDepotCompteUser
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel p_model);
        public Task<string>SignInAsync(SignInModel p_model);

    }
}
