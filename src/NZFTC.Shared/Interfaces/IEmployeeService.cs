// IEmployeeService
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.Shared.Dtos;

namespace NZFTC.Shared.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int employeeId);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task<EmployeeDto?> UpdateAsync(UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(int employeeId);
    }
}