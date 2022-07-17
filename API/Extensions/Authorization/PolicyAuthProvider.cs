using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

public class PolicyAuthProvider : DefaultAuthorizationPolicyProvider
{
    public PolicyAuthProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }
    public override Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        if (!policyName.StartsWith(PAuthorizeAttribute.Prefix, StringComparison.OrdinalIgnoreCase))
        {
            return base.GetPolicyAsync(policyName);
        }

        var permissionNames = policyName.Substring(PAuthorizeAttribute.Prefix.Length).Split(',');

        var policy = new AuthorizationPolicyBuilder()
            .RequireClaim(Permissions.Authentication.GetAllUser, permissionNames)
            .Build();

        return Task.FromResult(policy);
    }

}