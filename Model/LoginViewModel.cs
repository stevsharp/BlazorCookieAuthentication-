using System.ComponentModel.DataAnnotations;

namespace BlazorAuthenticationWithoutAspCoreIdentity.Model;

public class LoginViewModel
{
    [Required(AllowEmptyStrings =false , ErrorMessage = "Please Provide a User Name")]
    public string? UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide a Password")]
    public string? Password { get; set; }
}
