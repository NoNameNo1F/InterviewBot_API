namespace Interviewbot_API.API.Modules.Auth.Dtos;

public sealed record RegisterUserRequestDto(
    string Email,
    string FirstName,
    string LastName,
    DateTime DoB,
    string Password,
    string RePassword
);