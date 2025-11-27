using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;

using System.Threading.Tasks;

namespace NZFTC.Server.Pages.Grievances
{
    public class MyCasesModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public MyCasesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<GrievanceDto> Grievances { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                // Backend needs GET /api/grievance/employee/{employeeId} endpoint
                // For now shows all grievances 
                // after auth implemented can filter grevience per EmployeeId
                var grievances = await _httpClient.GetFromJsonAsync<List<GrievanceDto>>("http://localhost:5000/api/grievance");
                Grievances = grievances ?? new List<GrievanceDto>();

                // int currentEmployeeId = 1; // Get from User.Claims
                // Grievances = grievances.Where(g => g.EmployeeId == currentEmployeeId).ToList();
            }
            catch
            {
                Grievances = new List<GrievanceDto>();
            }
        }
    }
}            