// IPayrollService
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.Shared.Dtos;

namespace NZFTC.Shared.Interfaces
{
    public interface IPayrollService
    {
        Task<IEnumerable<PayrollDto>> GetAllAsync();
        Task<PayrollDto?> GetByIdAsync(int payrollId);
        Task<PayrollDto> CreateAsync(CreatePayrollDto dto);
        Task<PayrollDto?> UpdateAsync(PayrollDto dto);
        Task<bool> DeleteAsync(int payrollId);
    }
}