using CliFx;
using Microsoft.Extensions.DependencyInjection;
using VOL.Test.Tool.Services;

Serve.Run(async services =>
{
    services.AddRemoteRequest();
    services.AddScoped<AutoPublish>();

    await new CliApplicationBuilder()
        .AddCommandsFromThisAssembly()
        .Build()
        .RunAsync();
},silence:true);