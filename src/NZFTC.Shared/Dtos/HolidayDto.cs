// HolidayDto
using System;

namespace NZFTC.Shared.Dtos
{
    public class HolidayDto
    {
        // ER-aligned
        public int HolidayId { get; set; }
        // legacy alias
        public int Id
        {
            get => HolidayId;
            set => HolidayId = value;
        }

        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;

        // some services expected Region previously; keep nullable to avoid breaking
        public string? Region { get; set; }
    }
}