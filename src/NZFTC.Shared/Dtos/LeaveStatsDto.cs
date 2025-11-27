namespace NZFTC.Shared.Dtos
{
    public class LeaveStatsDto
    {
        public int TotalRequests { get; set; }
        public int PendingRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int RejectedRequests { get; set; }

        public int ApprovedThisMonth { get; set; }
        public int RejectedThisMonth { get; set; }
        public int TotalThisMonth { get; set; }
    }
}