using BlazorAuthenticationWithoutAspCoreIdentity.Model;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace BlazorAuthenticationWithoutAspCoreIdentity.Components.Pages;
public partial class Login
{
    [SupplyParameterFromForm]
    protected LoginViewModel LoginViewModel { get; set; } = new();

    protected string? ErrorMessage { get; set; }
    
    [CascadingParameter]
    public HttpContext? _httpContent { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }
    protected async Task AuthenticateUser()
    {
        if (LoginViewModel.UserName == "admin" && LoginViewModel.Password == "pass")
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name ,"admin"),
                new Claim(ClaimTypes.Role ,"admin")

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await _httpContent.SignInAsync(principal);

            Navigation.NavigateTo("/");
        }

        else {
            ErrorMessage = "User Not Found !!!";
        }
    }
}
