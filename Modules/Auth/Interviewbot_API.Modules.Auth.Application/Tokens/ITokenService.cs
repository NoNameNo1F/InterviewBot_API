using Interviewbot_API.Modules.Auth.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Application.Tokens;

public interface ITokenService
{
    string CreateAccessToken(User user, string tokenType);
    string CreateRefreshToken(User user, Guid tokenId, DateTime expiryDate, string tokenType);
    Guid DecodeToken(string token);
    bool IsTokenExpired(string token);
    bool DecodableToken(string token);
}