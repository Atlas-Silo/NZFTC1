using System;

public class LeaveRequest
{
    public int LeaveRequestId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Type { get; set; } = "Annual";
    public string Status { get; set; } = "Pending";
    public DateTime RequestedOn { get; set; } = DateTime.UtcNow;

    public Employee? Employee { get; set; }
}
