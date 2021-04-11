using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OuthServer
{
    public static class GenerateToken
    {
        public static string GenerateJwtToken(string userName)
        {
            if (userName == null)
                return null;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = "www.siemens.com",
                Issuer = "www.siemens.com",
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userName) }),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = credentials
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
