namespace NZFTC.Shared.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public int Id
        {
            get => EmployeeId;
            set => EmployeeId = value;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name => $"{FirstName} {LastName}";
        
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Initials => $"{FirstName?[0]}{LastName?[0]}";

        public DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
    }
}