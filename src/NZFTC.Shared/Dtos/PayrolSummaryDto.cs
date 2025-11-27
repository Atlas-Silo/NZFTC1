namespace NZFTC.Shared.Dtos
{
    public class PayrollSummaryDto
    {
        public int TotalEmployees { get; set; }
        public decimal TotalGross { get; set; }
        public decimal TotalNet { get; set; }

        public int ActiveEmployees { get; set; }
        public decimal TotalBaseSalaries { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal TotalNetPayroll { get; set; }
    }
}