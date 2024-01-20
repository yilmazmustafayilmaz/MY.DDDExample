namespace Domain.Aggragate.Packages;

public class Package : BaseAuditableEntity
{
    private string name;
    public string Name
    {
        get => name;
        set =>
            name = value switch
            {
                var _ when string.IsNullOrEmpty(value) => throw new ArgumentNullException(nameof(Name)),
                _ => value.ToLower().Trim()
            };
    }
}
