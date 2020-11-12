namespace RoleBaseAuth.Shared
{
    using Microsoft.AspNetCore.Authorization;

    public static class PolicyHelpers
    {
        public static AuthorizationOptions AddMarsPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy("MarsOnlyPolicy", policy => policy.RequireClaim("planet", "Mars"));
            return options;
        }
    }
}
