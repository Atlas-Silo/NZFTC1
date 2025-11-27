// CreateEmployeeDto
using System;

namespace NZFTC.Shared.Dtos
{
    public class CreateEmployeeDto
    {
        // keep both names to match callers
        public string? EmployeeNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
    }
}