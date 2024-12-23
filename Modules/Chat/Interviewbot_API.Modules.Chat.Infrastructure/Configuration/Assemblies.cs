using System.Reflection;
using Interviewbot_API.Modules.Chat.Application.Contracts;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IChatModule).Assembly;
}