// PayrollDto
using System;

namespace NZFTC.Shared.Dtos
{
    public class PayrollDto
    {
        // ER-aligned
        public int PayrollId { get; set; }
        // legacy alias
        public int Id
        {
            get => PayrollId;
            set => PayrollId = value;
        }

        public int EmployeeId { get; set; }
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }
        public decimal GrossPay { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPay { get; set; }
        public DateTime GeneratedOn { get; set; }
    }
}