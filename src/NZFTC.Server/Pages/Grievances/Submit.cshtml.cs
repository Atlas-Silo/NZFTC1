using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Pages.Grievances;

public class SubmitModel : PageModel
{
    private readonly HttpClient _httpClient;

    public SubmitModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [BindProperty]
    public string Subject { get; set; } = string.Empty;

    [BindProperty]
    public string Details { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
        // Initialize form
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrEmpty(Subject) || string.IsNullOrEmpty(Details))
        {
            ModelState.AddModelError(string.Empty, "Subject and details are required.");
            return Page();
        }

        try
        {
            // TODO: Get actual EmployeeId from User.Claims after auth is wired up
            var grievance = new GrievanceDto
            {
                EmployeeId = 1, // Mock - should come from authenticated user
                Subject = Subject,
                Details = Details,
                SubmittedOn = DateTime.Now,
                Status = "New"
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/grievance", grievance);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Grievances/MyCases");
            }
            else
            {
                ErrorMessage = "Failed to submit grievance. Please try again.";
                return Page();
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error submitting grievance: {ex.Message}";
            return Page();
        }
    }
}
