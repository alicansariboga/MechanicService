using MechanicService.Application.Dtos;
using MechanicService.Application.Features.Mediator.Results.AppUserResults;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MechanicService.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(result.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, result.Role)); //new client
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.AppUserId.ToString()));

            if (!string.IsNullOrWhiteSpace(result.Username))
            {
                claims.Add(new Claim("Username", result.Username));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            // identify token
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
