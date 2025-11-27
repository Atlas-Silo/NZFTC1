namespace NZFTC.Shared.Dtos
{
    public class LeaveRequestDto
    {
        public int LeaveRequestId { get; set; }
        public int Id { get => LeaveRequestId; set => LeaveRequestId = value; }

        public int EmployeeId { get; set; }
        public string EmployeeInitials { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Service expects Type, UI expects LeaveType
        public string Type { get; set; } = string.Empty;
        public string LeaveType { get; set; } = string.Empty;

        public int Duration { get; set; }
        public string Status { get; set; } = string.Empty;

        // Service expects RequestedOn, UI expects SubmittedDate
        public DateTime RequestedOn { get; set; }
        public DateTime SubmittedDate { get; set; }

        public string Reason { get; set; } = string.Empty;
        public string ApproverName { get; set; } = string.Empty;
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
    }
}