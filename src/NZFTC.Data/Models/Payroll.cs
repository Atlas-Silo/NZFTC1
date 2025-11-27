using System;

public class Payroll
{
    public int PayrollId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime PayPeriodStart { get; set; }
    public DateTime PayPeriodEnd { get; set; }
    public decimal GrossPay { get; set; }
    public decimal Tax { get; set; }
    public decimal NetPay { get; set; }
    public DateTime GeneratedOn { get; set; } = DateTime.UtcNow;

    public Employee? Employee { get; set; }
}
