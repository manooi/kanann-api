using Microsoft.AspNetCore.Authorization;

namespace App.Service.Authorization;

public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        // If user does not have the scope claim, get out of here
        if (!context.User.HasClaim(c => c.Type == AppConstant.Auth0RoleClaimType))
            return Task.CompletedTask;

        // Split the scopes string into an array
        var role = context.User.FindFirst(c => c.Type == AppConstant.Auth0RoleClaimType).Value.Split(' ');

        // Succeed if the scope array contains the required scope
        if (role.Any(s => s == requirement.Role || requirement.Role.Contains(s)))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}