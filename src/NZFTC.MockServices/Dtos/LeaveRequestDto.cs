using System;

namespace NZFTC.EmployeeMgmt.MockServices.Dtos
{
  public class LeaveRequestDto
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
  }
}