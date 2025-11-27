namespace NZFTC.Shared.Dtos
{
    public class YearSummaryDto
    {
        public int Year { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal NetIncome { get; set; }
        public decimal TotalTax { get; set; }
    }
}