// IHolidayService
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.Shared.Dtos;

namespace NZFTC.Shared.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayDto>> GetAllAsync();
        Task<HolidayDto?> GetByIdAsync(int holidayId);
        Task<HolidayDto> CreateAsync(HolidayDto dto);
        Task<HolidayDto?> UpdateAsync(HolidayDto dto);
        Task<bool> DeleteAsync(int holidayId);
    }
}