using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;

namespace BlazorAuthenticationWithoutAspCoreIdentity.Components.Pages;
public partial class Logout
{
    [CascadingParameter]
    public HttpContext? _httpContent { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }
    protected override async Task OnInitializedAsync()
    {
        base.OnInitializedAsync();

        if (this._httpContent.User.Identity.IsAuthenticated)
        {
            await _httpContent.SignOutAsync();

            Navigation.NavigateTo("/logout", true);
        }
    }
}
