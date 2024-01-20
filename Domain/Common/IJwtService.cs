using System.Security.Claims;

namespace Domain.Common;

public interface IJwtService
{
    string BuildToken(IEnumerable<Claim> claims);
}
