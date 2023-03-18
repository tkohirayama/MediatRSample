using MediatR;
using MyMediatR.Sample.App;
using MyMediatR.Sample.App.behaviors;
using MyMediatR.Sample.Command;
using MyMediatR.Sample.Command.behaviors;
using MyMediatR.Sample.CommandImpl;
using MyMediatR.Sample.Notification;
using MyMediatR.Sample.Stream;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMediatR(cfg =>
        {
            // cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(SampleCommandHandler).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(SampleNotification).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(SampleStream).Assembly);
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        services.AddHostedService<Worker>();
    })
    .ConfigureLogging(builder =>
    {
        builder.ClearProviders();
        builder.AddConsole();
    });

await builder.Build().RunAsync();
