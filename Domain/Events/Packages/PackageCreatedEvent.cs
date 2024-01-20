using Domain.Aggragate.Packages;

namespace Domain.Events.Packages;

public sealed class PackageCreatedEvent : BaseEvent
{
    public PackageCreatedEvent(Package item)
        => Item = item;

    public Package Item { get; }
}
