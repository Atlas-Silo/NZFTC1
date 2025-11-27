namespace NZFTC.Data.Entities
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime RequestedOn { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}