using Interviewbot_API.BuildingBlocks.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Domain.Entities;

public class Otp : Entity
{
    public Guid OtpId { get; set; }
    public int OtpType { get; set; }
    public string Code { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiryAt { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}