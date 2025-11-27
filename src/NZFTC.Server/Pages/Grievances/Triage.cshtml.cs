using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Pages.Grievances;

public class TriageModel : PageModel
{
    private readonly HttpClient _httpClient;

    public TriageModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? StatusFilter { get; set; }

    public List<GrievanceDto> Grievances { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            // Admin sees all grievances
            var grievances = await _httpClient.GetFromJsonAsync<List<GrievanceDto>>("http://localhost:5000/api/grievance");
            Grievances = grievances ?? new List<GrievanceDto>();

    
            // For now, filter in memory
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Grievances = Grievances.Where(g =>
                    g.Subject.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    g.EmployeeId.ToString().Contains(SearchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(StatusFilter))
            {
                Grievances = Grievances.Where(g =>
                    g.Status.Equals(StatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        catch
        {
            Grievances = new List<GrievanceDto>();
        }
    }
}
