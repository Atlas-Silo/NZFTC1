using System;

namespace NZFTC.EmployeeMgmt.MockServices.Dtos
{
  public class GrievanceDto
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Status { get; set; } = "Submitted";
  }
}