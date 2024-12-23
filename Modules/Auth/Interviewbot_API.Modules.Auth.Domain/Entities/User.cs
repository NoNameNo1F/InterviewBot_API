using Interviewbot_API.BuildingBlocks.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Domain.Entities;

public class User : Entity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}