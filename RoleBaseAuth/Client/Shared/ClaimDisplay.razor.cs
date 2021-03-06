namespace RoleBaseAuth.Client.Shared
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    public partial class ClaimDisplay
    {
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Parameter]
        public string ClaimType { get; set; }

        public string Claims { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            System.Security.Claims.ClaimsPrincipal user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> userClaims = user.Claims.Where(claim => claim.Type.Equals(ClaimType));
                Claims = userClaims.Any() ? userClaims.Select(claim => claim.Value).Aggregate(AddClaims) : "";
            }
        }

        private static string AddClaims(string left, string right) => left + ", " + right;
    }
}