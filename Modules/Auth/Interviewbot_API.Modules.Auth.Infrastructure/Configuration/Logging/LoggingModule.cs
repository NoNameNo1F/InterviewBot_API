﻿using Autofac;
using Serilog;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Logging;

internal class LoggingModule : Module
{
    private readonly ILogger _logger;

    internal LoggingModule(ILogger logger)
    {
        _logger = logger;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(_logger)
            .As<ILogger>()
            .SingleInstance();
    }
}