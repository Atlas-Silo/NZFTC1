// IGrievanceService
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.Shared.Dtos;

namespace NZFTC.Shared.Interfaces
{
    public interface IGrievanceService
    {
        Task<IEnumerable<GrievanceDto>> GetAllAsync();
        Task<GrievanceDto?> GetByIdAsync(int grievanceId);
        Task<GrievanceDto> CreateAsync(GrievanceDto dto);
        Task<GrievanceDto?> UpdateAsync(GrievanceDto dto);
        Task<bool> DeleteAsync(int grievanceId);
    }
}