namespace Interviewbot_API.API.Modules.Auth.Dtos;

public sealed record ChangePasswordRequestDto(
    string Email,
    string OldPassword,
    string NewPassword,
    string ReNewPassword);