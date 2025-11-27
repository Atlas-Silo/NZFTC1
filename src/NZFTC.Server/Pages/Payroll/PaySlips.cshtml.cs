using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;

namespace NZFTC.Server.Pages.Payroll
{
    public class PaySlipsModel : PageModel
    {
        public PaySlipDto? LatestPaySlip { get; set; }
        public YearSummaryDto YearSummary { get; set; } = new();
        public List<PaySlipDto> PaySlips { get; set; } = new();

        public void OnGet()
        {
            // TODO: populate LatestPaySlip, YearSummary, PaySlips
        }
    }
}