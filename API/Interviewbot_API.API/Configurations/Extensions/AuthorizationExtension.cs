using Interviewbot_API.API.Common;
using Interviewbot_API.BuildingBlocks.Application.Constrains;
using Interviewbot_API.BuildingBlocks.Application.Constrains.Constains;
using Microsoft.AspNetCore.Authorization;

namespace Interviewbot_API.API.Configurations.Extensions;

internal static class AuthorizationExtension
{
    internal static IServiceCollection AddApiAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(HeaderConstraints.TokenType, TokenTypeNames.Access)
                .Build();
        });

        return services;
    }
}