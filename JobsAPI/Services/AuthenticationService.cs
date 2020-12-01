using JobsAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JobsAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appSettings;
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        private List<ApplicationUser> users = new List<ApplicationUser>()
        {
            new ApplicationUser
            {
                Id =1,
                UserName = "cup",
                FirstName = "Coffee",
                LastName = "Sugar",
                Password = "mineralWater",
            }
        };

        public ApplicationUser Authenticate(string userName, string password)
        {
            var user = users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.ApiKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1.10")
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Remove the password while returning a user
            user.Password = null;

            return user;
        }
    }
}
