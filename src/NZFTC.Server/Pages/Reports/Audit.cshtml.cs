using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;

namespace NZFTC.Server.Pages.Reports
{
    public class AuditReportModel : PageModel
    {
        public List<AuditLogDto> AuditLogs { get; set; } = new();

        public void OnGet()
        {
            // TODO: populate AuditLogs from service
        }
    }
}