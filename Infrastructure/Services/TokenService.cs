using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService(IConfiguration _configuration) : ITokenService
    {
        public string GenerateAccessToken(User user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Token"]);

                var tokenDespcriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("Email",user.Email),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("UserId",user.Id.ToString()),
                    //new Claim( ClaimTypes.Role,user.Role.Name)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDespcriptor);
                return tokenHandler.WriteToken(token);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GenerateRefreshToken()
        {
            try
            {
                return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
