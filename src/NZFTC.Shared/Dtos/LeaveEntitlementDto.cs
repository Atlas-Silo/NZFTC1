using System;

namespace NZFTC.Shared.Dtos
{
    public class LeaveEntitlementDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public int AnnualLeave { get; set; }
        public int SickLeave { get; set; }
        public int BereavementLeave { get; set; }
    }
}