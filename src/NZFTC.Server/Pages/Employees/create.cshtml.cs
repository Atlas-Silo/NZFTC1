using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Server.Pages.Employees
{
    public class CreateEmployeeModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateEmployeeModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public CreateEmployeeDto Employee { get; set; } = new();

        public void OnGet()
        {            
        }

        public async Task<IActionResult> OnPostAsync()
        {

            // centralise validation and error handling
            if (!ModelState.IsValid)
            {
                return Page();
            }
 
            try
            {
                
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/employee", Employee);

                if (response.IsSuccessStatusCode)
                {
                  
                    return RedirectToPage("Index");
                }
                else
                {
                    // Failed - show error
                    ModelState.AddModelError(string.Empty, "Failed to create employee. Please try again.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Error handling
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
// instant feedback validation scripts 
// @section Scripts {
//     <partial name="_ValidationScriptsPartial" />
// }