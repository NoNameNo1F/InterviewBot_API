using Interviewbot_API.BuildingBlocks.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Domain.Entities;

public class RefreshToken : Entity
{
    public Guid TokenId { get; set; }
    public string Secret { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiryAt { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}