using Autofac;
using Autofac.Extensions.DependencyInjection;
using Interviewbot_API.API.Common;
using Interviewbot_API.API.Configurations.Extensions;
using Interviewbot_API.API.Configurations.Validations;
using Interviewbot_API.BuildingBlocks.Application.Constrains;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Configuration.Auth;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Crypto;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Token;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Chat;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Extensions
builder.Services.AddApiSwaggerDocumentation();
builder.Services.AddApiVersions();
builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddApiAuthorization();
builder.Services.AddDevelopmentProblemDetails();

// Registering Module
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        // Configure Logging Service
        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        // Configure Token Service
        var tokensConfiguration = new TokensConfiguration(
            builder.Configuration["Jwt:Issuer"],
            builder.Configuration["Jwt:Audience"],
            builder.Configuration["Jwt:Key"]
        );
        var cryptosConfiguration = new CryptosConfiguration(
            builder.Configuration["Secret:Salt"]
        );
        
        // Register module here
        container.RegisterModule(new ChatAutoFacModule());
        container.RegisterModule(new AuthAutoFacModule());

        // Initialize module here
        Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Startup.Initialize(
            new DatabaseConfiguration(
                builder.Configuration["Databases:ChatModuleDb:NoSql:MongoDb:ConnectionString"],
                builder.Configuration["Databases:ChatModuleDb:NoSql:MongoDb:DatabaseName"]),
            builder.Configuration["Databases:ChatModuleDb:NoSql:Redis:ConnectionString"],
            logger
        );
        
        Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Startup.Initialize(
            builder.Configuration["Databases:AuthModuleDb:Sql:SqlServer:ConnectionString"],
            tokensConfiguration,
            cryptosConfiguration,
            logger
        );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDevelopmentProblemDetails();
    // app.UseExceptionHandler();
    app.UseSwaggerDocumentation();

    app.UseCors(options => options
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders(HeaderConstraints.XPagination));
}
else
{
    app.UseExceptionHandler(options => { });
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
