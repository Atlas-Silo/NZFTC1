using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;

namespace NZFTC.Pages.Leave
{
    public class LeaveApprovalsModel : PageModel
    {
        public LeaveStatsDto Stats { get; set; } = new();
        public string? SearchQuery { get; set; }
        public List<LeaveRequestDto> LeaveRequests { get; set; } = new();

        public void OnGet(string? searchQuery)
        {
            SearchQuery = searchQuery;
            // TODO: populate Stats and LeaveRequests
        }
    }
}