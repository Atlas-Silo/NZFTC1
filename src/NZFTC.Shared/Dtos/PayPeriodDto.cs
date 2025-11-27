using System;

namespace NZFTC.Shared.Dtos
{
    public class PayPeriodDto
    {
        public string PeriodName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}