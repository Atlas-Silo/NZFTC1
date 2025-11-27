// src/NZFTC.Shared/Dtos/UpdateEmployeeDto.cs
using System;

namespace NZFTC.Shared.Dtos
{
    public class UpdateEmployeeDto
    {
        public int EmployeeId { get; set; }

        public int Id
        {
            get => EmployeeId;
            set => EmployeeId = value;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
    }
}