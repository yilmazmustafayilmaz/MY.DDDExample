using Domain.ValueObjects;

namespace Domain.Aggragate.Users;

public class User : BaseAuditableEntity
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

    private string surname;
    public string Surname
    {
        get => surname;
        set =>
            surname = value switch
            {
                var _ when string.IsNullOrEmpty(value) => throw new ArgumentNullException(nameof(Surname)),
                _ => value.ToLower().Trim()
            };
    }

    private string email;
    public string Email
    {
        get => email;
        set =>
            email = value switch
            {
                var _ when string.IsNullOrEmpty(value) => throw new ArgumentNullException(nameof(Email)),
                var _ when !value.Contains('@') => throw new ArgumentException("Invalid_Email"),
                _ => value.ToLower().Trim()
            };
    }

    private string role;
    public string Role
    {
        get => role;
        set =>
            role = value switch
            {
                var _ when string.IsNullOrEmpty(value) => throw new ArgumentNullException(nameof(Role)),
                _ => value.ToLower().Trim()
            };
    }

    public Password Password { get; private set; }
    public void SetPassword(byte[] hash, byte[] salt) => Password = (new Password().SetPassword(hash, salt));
}
