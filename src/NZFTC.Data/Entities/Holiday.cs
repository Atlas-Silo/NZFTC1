namespace NZFTC.Data.Entities
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}