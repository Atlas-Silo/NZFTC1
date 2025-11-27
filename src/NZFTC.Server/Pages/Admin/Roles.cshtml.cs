using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos; // DTOs LOCATION in NZFTC.SHARED

namespace NZFTC.Pages.Admin
{
    public class RolesModel : PageModel
    {
        public bool IsSuccess { get; set; }
        public int? SelectedEmployeeId { get; set; }
        public List<EmployeeDto> EmployeeList { get; set; } = new();
        public EmployeeDto? SelectedEmployee { get; set; }
        public string? Role { get; set; }
        public List<EmployeeDto> AllEmployees { get; set; } = new();

        public void OnGet()
        {
            // TODO: populate EmployeeList and AllEmployees from service
        }

        public void OnPostAssignRole(int employeeId, string role)
        {
            SelectedEmployeeId = employeeId;
            Role = role;
            IsSuccess = true;
        }
    }
}