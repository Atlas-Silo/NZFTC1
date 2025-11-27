namespace NZFTC.Data.Entities
{
    public class Grievance
    {
        public int GrievanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Status { get; set; } = "Submitted";

        public Employee Employee { get; set; } = null!;
    }
}