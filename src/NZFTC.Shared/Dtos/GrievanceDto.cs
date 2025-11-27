// GrievanceDto
using System;

namespace NZFTC.Shared.Dtos
{
    public class GrievanceDto
    {
        // ER-aligned
        public int GrievanceId { get; set; }
        // legacy alias
        public int Id
        {
            get => GrievanceId;
            set => GrievanceId = value;
        }

        public int EmployeeId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}