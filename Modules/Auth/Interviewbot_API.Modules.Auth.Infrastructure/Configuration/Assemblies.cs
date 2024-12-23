using System.Reflection;
using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAuthModule).Assembly;
}