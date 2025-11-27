using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared;

namespace NZFTC.Server.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public bool IsSuccess { get; set; }
        public string? Email { get; set; }

        // Add ErrorMessage property so Razor can bind to it
        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet(string email) => Email = email;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input. Please correct the errors and try again.";
                return Page();
            }

            // TODO: call password reset service
            IsSuccess = true;

            // If something fails, set ErrorMessage accordingly
            // ErrorMessage = "Password reset failed. Please try again.";

            return Page();
        }

        public class InputModel
        {
            [Required, EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required, DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Required, DataType(DataType.Password), Compare("Password")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }
    }
}