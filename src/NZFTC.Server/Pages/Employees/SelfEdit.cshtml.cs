using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Pages.Employees
{
    public class SelfEditEmployeeModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public SelfEditEmployeeModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
 
        [BindProperty]
        public UpdateEmployeeDto Employee { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                // Get employee details to display before editing
                var employeeDto = await _httpClient.GetFromJsonAsync<EmployeeDto>($"http://localhost:5000/api/employee/{id}");

                // check if employee(id) exists
                if (employeeDto == null)
                {
                    return NotFound();
                }

                // Map EmployeeDto >< UpdateEmployeeDto
                Employee = new UpdateEmployeeDto
                {
                    Id = employeeDto.Id,
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Email = employeeDto.Email,
                    Role = employeeDto.Role,
                    DateHired = employeeDto.DateHired,
                    Salary = employeeDto.Salary
                };

                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/employee/{Employee.Id}", Employee);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update employee. Please try again.");
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