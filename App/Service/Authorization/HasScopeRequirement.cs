using Microsoft.AspNetCore.Authorization;

namespace App.Service.Authorization;

public class HasScopeRequirement : IAuthorizationRequirement
{
    public string Role { get; }

    public HasScopeRequirement(string role)
    {
        Role = role ?? throw new ArgumentNullException(nameof(role));
    }
}