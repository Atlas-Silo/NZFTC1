using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using NZFTC.Data.Entities;

namespace NZFTC.Server.Pages.Account
{
    public class LoginModel : PageModel
    {
     
        // updated to match identity useage in program.cs <User>
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ErrorMessage { get; set; }


        // Login form GET
        public void OnGet(string? returnUrl = null)
        {
            // Render the login form
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _signInManager.PasswordSignInAsync(
                Input.UserName, //added for username
                //Input.Email, 2 inputs exeeds lockout threshold
                Input.Password,
                Input.RememberMe,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToPage("/Dashboard/Admin"); //insert role logic here
            }

            ErrorMessage = "Invalid login attempt.";
            return Page();
        }

        public class InputModel
        {
            // Username field for PasswordSignInAsync
            [Required, DataType(DataType.Text)]
            public string UserName { get; set; } = string.Empty;

            //[Required, EmailAddress]
            //public string Email { get; set; } = string.Empty;

            [Required, DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public bool RememberMe { get; set; }
        }
    }
}