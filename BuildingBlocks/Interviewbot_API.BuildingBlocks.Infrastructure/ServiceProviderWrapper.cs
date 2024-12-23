using Autofac;

namespace Interviewbot_API.BuildingBlocks.Infrastructure;

public class ServiceProviderWrapper : IServiceProvider
{
    private readonly ILifetimeScope _lifetimeScope;

    public ServiceProviderWrapper(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    #nullable enable
    public object? GetService(Type serviceType)
    {
        return _lifetimeScope.ResolveOptional(serviceType);
    }
}