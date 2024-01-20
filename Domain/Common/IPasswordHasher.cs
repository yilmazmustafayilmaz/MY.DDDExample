namespace Domain.Common;

public interface IPasswordHasher
{
    (byte[] hash, byte[] salt) HashPassword(string password, byte[] salt = null);
    bool VerifyHashedPassword(string password, byte[] salt, byte[] hashedPassword);
}
