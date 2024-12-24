namespace Interviewbot_API.API.Modules.Auth.Dtos;

public sealed record ForgotPasswordRequestDto(string Email, int OtpType);