using Domain.Events.Packages;

namespace Application.UseCase.Packages.EventHandler;

public sealed class PackageCreatedEventHandler : INotificationHandler<PackageCreatedEvent>
{
    public Task Handle(PackageCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Created Success");
        return Task.CompletedTask;
    }
}
