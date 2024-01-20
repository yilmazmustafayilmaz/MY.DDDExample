namespace Domain.ValueObjects;

public class Password : ValueObject
{
    public byte[] Hash { get; private set; }
    public byte[] Salt { get; private set; }

    public Password SetPassword(byte[] hash, byte[] salt)
    {
        Hash = hash;
        Salt = salt;
        return this;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
