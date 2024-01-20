using Domain.Common;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 24;
    private const int Iterations = 10000;

    public (byte[] hash, byte[] salt) HashPassword(string password, byte[] salt = null)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        var currentSalt = salt ?? GetRandomSalt();
        using Rfc2898DeriveBytes deriveBytes = new(bytes, currentSalt, Iterations);
        return (deriveBytes.GetBytes(SaltSize), currentSalt);
    }

    public bool VerifyHashedPassword(string password, byte[] salt, byte[] hashedPassword)
        => HashPassword(password, salt).hash.SequenceEqual(hashedPassword);

    private byte[] GetRandomSalt()
    {
        var saltBytes = new byte[SaltSize];
        RandomNumberGenerator.Create().GetBytes(saltBytes);
        return saltBytes;
    }
}
