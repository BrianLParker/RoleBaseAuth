namespace RoleBaseAuth.Shared
{
    using Microsoft.AspNetCore.Authorization;

    public static class AuthorizationOptionsExtensions
    {
        public static AuthorizationOptions AddMarsPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy("MarsOnlyPolicy", policy => policy.RequireClaim(CustomClaimTypes.Planet, "Mars"));
            return options;
        }
    }
}
