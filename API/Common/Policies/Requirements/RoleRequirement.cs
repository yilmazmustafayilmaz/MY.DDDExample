using Microsoft.AspNetCore.Authorization;

namespace API.Common.Policies.Requirements;

public class RoleRequirement : IAuthorizationRequirement
{
    public RoleRequirement(string role) => Role = role;

    public string Role { get; }
}
