// CreatePayrollDto
using System;

namespace NZFTC.Shared.Dtos
{
    public class CreatePayrollDto
    {
        public int EmployeeId { get; set; }
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }
        public decimal GrossPay { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPay { get; set; }

        // optional local override
        public DateTime? GeneratedOn { get; set; }
    }
}