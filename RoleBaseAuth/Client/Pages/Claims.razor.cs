namespace RoleBaseAuth.Client.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components;

    public partial class Claims
    {
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        async Task GetClaimsPrincipalData()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
                claims = user.Claims;
            }
            else
            {
                authMessage = "The user is NOT authenticated";
            }
        }

        string userId => claims.FirstOrDefault(a => a.Type == "sub")?.Value ?? "";
        string email => claims.FirstOrDefault(a => a.Type == "email")?.Value ?? "";
        string authMessage;
        IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    }
}