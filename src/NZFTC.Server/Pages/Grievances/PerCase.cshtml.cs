using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Server.Pages.Grievances
{
    public class PerCaseModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public PerCaseModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public GrievanceDto? Grievance { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                ErrorMessage = "No grievance ID provided.";
                return Page();
            }

            try
            {
                Grievance = await _httpClient.GetFromJsonAsync<GrievanceDto>($"http://localhost:5000/api/grievance/{id}");

                if (Grievance == null)
                {
                    ErrorMessage = $"Grievance with ID {id} not found.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading grievance: {ex.Message}";
            }

            return Page();
        }
    }
}
