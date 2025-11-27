using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;

namespace NZFTC.Pages.Leave
{
    public class MyLeaveRequestsModel : PageModel
    {
        public LeaveStatsDto Stats { get; set; } = new();
        public List<LeaveRequestDto> LeaveRequests { get; set; } = new();

        public void OnGet()
        {
            // TODO: populate Stats and LeaveRequests
        }
    }
}