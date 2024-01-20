using API.Common.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API.Common.Policies.Handler;

public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        IEnumerable<IAuthorizationRequirement> requirements = context.Requirements;

        if (!context.User.HasClaim(x => x.Type == ClaimTypes.Role))
        {
            context.Fail(new AuthorizationFailureReason(this, "User token has no role"));
            return Task.CompletedTask;
        }

        var role = context.User.FindFirst(x => x.Type == ClaimTypes.Role).Value;

        string[] roles = role.Split(',');

        if (!roles.Any(x => requirements.Any(y => y.GetType() == typeof(RoleRequirement) && ((RoleRequirement)y).Role == x)))
        {
            context.Fail(new AuthorizationFailureReason(this, "User token doesn't has the required role"));
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}