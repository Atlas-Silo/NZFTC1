using System;

public class Grievance
{
    public int GrievanceId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
    public string Subject { get; set; } = null!;
    public string Details { get; set; } = null!;
    public string Status { get; set; } = "Open";

    public Employee? Employee { get; set; }
}
