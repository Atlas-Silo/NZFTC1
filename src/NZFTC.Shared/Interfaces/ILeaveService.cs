// ILeaveService
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.Shared.Dtos;

namespace NZFTC.Shared.Interfaces
{
    public interface ILeaveService
    {
        Task<IEnumerable<LeaveRequestDto>> GetAllAsync();
        Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId);
        Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto dto);
        Task<LeaveRequestDto?> UpdateAsync(LeaveRequestDto dto);
        Task<bool> DeleteAsync(int leaveRequestId);
    }
}