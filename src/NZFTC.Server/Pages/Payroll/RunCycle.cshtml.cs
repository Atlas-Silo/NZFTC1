using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;

namespace NZFTC.Server.Pages.Payroll
{
    public class RunPayrollCycleModel : PageModel
    {
        public PayPeriodDto? PayPeriod { get; set; }
        public PayrollSummaryDto? Summary { get; set; }
        public string? Status { get; set; }
        public DateTime? LastProcessedDate { get; set; }

        public void OnGet()
        {
            // TODO: populate from payroll service
            PayPeriod = new PayPeriodDto
            {
                PeriodName = "Nov 2025",
                StartDate = new DateTime(2025, 11, 1),
                EndDate = new DateTime(2025, 11, 30)
            };

            Summary = new PayrollSummaryDto
            {
                TotalEmployees = 42,
                TotalGross = 123456.78m,
                TotalNet = 98765.43m
            };

            Status = "Ready";
            LastProcessedDate = DateTime.Now;
        }
    }
}