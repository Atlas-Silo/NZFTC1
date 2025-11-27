namespace NZFTC.Shared.Dtos
{
    public class PaySlipDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime PaymentDate { get; set; }

        public decimal GrossPay { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPay { get; set; }
        public decimal Deductions { get; set; }
    }
}