using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NZFTC.Pages.Account;

public class InvalidUserModel : PageModel
{
    public string? Message { get; set; }

    public void OnGet()
    {
        Message = "User account not found or invalid.";
    }
}
