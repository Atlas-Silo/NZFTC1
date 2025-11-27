// CreateLeaveRequestDto
using System;

namespace NZFTC.Shared.Dtos
{
    public class CreateLeaveRequestDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; } = string.Empty;

        // optional: if other callers used RequestedOn on create
        public DateTime? RequestedOn { get; set; }
    }
}