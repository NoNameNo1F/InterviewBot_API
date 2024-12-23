﻿using Autofac;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration;

public static class CompositionRoot
{
    private static IContainer _container;

    public static void SetContainer(IContainer container)
    {
        _container = container;
    }

    public static ILifetimeScope BeginLifetimeScope()
    {
        return _container.BeginLifetimeScope();
    }
}