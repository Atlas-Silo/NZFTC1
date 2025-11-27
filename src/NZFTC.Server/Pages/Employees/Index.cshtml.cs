using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Pages.Employees
{
    public class IndexEmployeeModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexEmployeeModel(IHttpClientFactory factory)
        {
            // Use a named client if you configured one in Program.cs
            _httpClient = factory.CreateClient("NZFTC");
        }

        public List<EmployeeDto> Employees { get; set; } = new();

        public int? TotalEmployees => Employees.Count;
        public int? ActiveEmployees => Employees.Count;
        public int? NewThisMonth => 0;
        public string SearchName { get; set; } = "";
        public int? PageStart => 1;
        public int? PageEnd => Employees.Count;

        public async Task OnGetAsync()
        {
            try
            {
                Employees = await _httpClient.GetFromJsonAsync<List<EmployeeDto>>("/api/employee")
                            ?? new List<EmployeeDto>();
            }
            catch (Exception)
            {
                Employees = new List<EmployeeDto>();
            }
        }
    }
}