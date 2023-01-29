using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.Redis.Demo;
using StackExchange.Redis;


using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var multiplexer = ConnectionMultiplexer.Connect("localhost");
        services.AddSingleton<IConnectionMultiplexer>(multiplexer);
        services.AddScoped<Redis>();
    })
    .Build();

var redis = host.Services.GetService<Redis>();
Console.WriteLine(await redis.GetOrSetString("asd"));

await host.RunAsync();