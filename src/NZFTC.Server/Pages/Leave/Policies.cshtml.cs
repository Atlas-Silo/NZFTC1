using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;

namespace NZFTC.Server.Pages.Leave
{
    public class LeavePoliciesModel : PageModel
    {
        public LeaveBalanceDto Balances { get; set; } = new();
        public LeaveEntitlementDto Entitlements { get; set; } = new();

        public void OnGet()
        {
            // TODO: populate Balances and Entitlements for the current employee.
            // Example placeholder data:
            Balances = new LeaveBalanceDto
            {
                EmployeeId = 1,
                EmployeeName = "Demo User",
                AnnualLeave = 8,
                SickLeave = 3,
                BereavementLeave = 1
            };

            Entitlements = new LeaveEntitlementDto
            {
                EmployeeId = 1,
                EmployeeName = "Demo User",
                AnnualLeave = 20,
                SickLeave = 10,
                BereavementLeave = 3
            };
        }
    }
}