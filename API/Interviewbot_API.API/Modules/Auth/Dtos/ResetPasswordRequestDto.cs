namespace Interviewbot_API.API.Modules.Auth.Dtos;

public sealed record ResetPasswordRequestDto(
    string Email,
    string NewPassword,
    string ReNewPassword);