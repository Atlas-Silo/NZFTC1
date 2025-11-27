using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Server.Pages.Employees
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteEmployeeModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public EmployeeDto Employee { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                // Get employee details to display before deleting
                Employee = await _httpClient.GetFromJsonAsync<EmployeeDto>($"http://localhost:5000/api/employee/{id}");

                if (Employee == null)
                {
                    return NotFound();
                }

                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                
                var response = await _httpClient.DeleteAsync($"http://localhost:5000/api/employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    // Success - redirect to index
                    return RedirectToPage("Index");
                }
                else
                {
                    // Failed - return to page with error
                    ModelState.AddModelError(string.Empty, "Failed to delete employee.");
                    return await OnGetAsync(id);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return await OnGetAsync(id);
            }
        }
    }
}    