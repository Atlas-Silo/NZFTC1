using System;

namespace NZFTC.Shared.Dtos
{
    public class AuditLogDto
    {
        public int AuditId { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }
}