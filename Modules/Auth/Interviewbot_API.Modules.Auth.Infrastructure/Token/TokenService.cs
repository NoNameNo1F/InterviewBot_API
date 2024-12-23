using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Interviewbot_API.BuildingBlocks.Application.Constrains;
using Interviewbot_API.BuildingBlocks.Application.Constrains.Constains;
using Interviewbot_API.BuildingBlocks.Application.Constrains.Enums;
using Interviewbot_API.Modules.Auth.Application.Tokens;
using Interviewbot_API.Modules.Auth.Domain.Entities;

using Microsoft.IdentityModel.Tokens;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Token;

public class TokenService : ITokenService
{
    private readonly TokensConfiguration _configuration;

    public TokenService(TokensConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string CreateAccessToken(User user, string tokenType = TokenTypeNames.Access)
    {
        var now = DateTime.UtcNow;
        var issuer = _configuration.Issuer;
        var audience = _configuration.Audience;
        var key = Encoding.ASCII.GetBytes(_configuration.Key!);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            // new Claim(JwtRegisteredClaimNames.Jti, tokenId.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture)),
        };
        
        claims.Add(new Claim(HeaderConstraints.TokenType, tokenType));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = now.AddMinutes((int)TokenLifeTimeDurations.AccessLifeTimeDuration),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    
    public string CreateRefreshToken(User user, Guid tokenId, DateTime currentTime, string tokenType = TokenTypeNames.Refresh)
    {
        var now = currentTime;
        var issuer = _configuration.Issuer;
        var audience = _configuration.Audience;
        var key = Encoding.ASCII.GetBytes(_configuration.Key);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture)),
            new Claim(JwtRegisteredClaimNames.Sid, tokenId.ToString()),
        };
        
        claims.Add(new Claim(HeaderConstraints.TokenType, tokenType));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = now.AddMinutes((int)TokenLifeTimeDurations.RefreshLifeTimeDuration),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public Guid DecodeToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
        return Guid.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value);
    }
    
    public bool IsTokenExpired(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
        var expTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expClaim)).UtcDateTime;
        return expTime < DateTime.UtcNow;
    }
    public bool DecodableToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(token))
        {
            return false;
        }
        
        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        if (jwtToken == null)
        {
            return false;
        }
    
        return true;
    }
}