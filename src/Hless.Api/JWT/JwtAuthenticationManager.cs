using Hless.Api.Models.Dto;
using Hless.Common.Repositories;
using Hless.Data.Models;
using Hless.Data.Tools.HashingTools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Hless.Api.JWT
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string tokenKey;
        private readonly IUserRepository users;

        public JwtAuthenticationManager(IServiceProvider services, string tokenKey)
        {
            this.tokenKey = tokenKey;
            this.users = services.GetService<IUserRepository>();
        }

        public string Authenticate(UserDto user)
        {
            string hashedPassword = Sha256.Hash(user.Password);

            List<User> userslst = users.GetUsersAsync().Result.ToList();

            if (!userslst.Any(u => u.Username == user.UserName && u.Password == hashedPassword))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Actor, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
