using System;
using System.Collections.Generic;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = "Employee"; // "Admin" or "Employee"
    public DateTime DateHired { get; set; }
    public decimal Salary { get; set; }

    // Navigation properties
    public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    public ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
    public ICollection<Grievance> Grievances { get; set; } = new List<Grievance>();
}
