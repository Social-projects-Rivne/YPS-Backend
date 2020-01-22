using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace YPS.Application.Auth.Helpers
{
    internal static class AuthHelpers
    {
        public static string GenerateToken(string apiKey, IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(apiKey));
            var jwt = new JwtSecurityToken(issuer: "YPS",
                audience: "Everyone",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt); //the method is called WriteToken but returns a string
        }
       
    }
}
