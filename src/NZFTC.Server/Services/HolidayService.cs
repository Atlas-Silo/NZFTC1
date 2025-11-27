// HolidayService
using Microsoft.EntityFrameworkCore;
using NZFTC.Data;
using NZFTC.Data.Entities;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZFTC.Server.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly AppDbContext _db;

        public HolidayService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<HolidayDto>> GetAllAsync()
        {
            return await _db.Holidays
                .AsNoTracking()
                .Select(h => new HolidayDto
                {
                    HolidayId = h.HolidayId,
                    Date = h.Date,
                    Name = h.Name,
                    // entity does not expose Region in your model; set null-safe value
                    Region = null
                })
                .ToListAsync();
        }

        public async Task<HolidayDto?> GetByIdAsync(int holidayId)
        {
            var h = await _db.Holidays.AsNoTracking().FirstOrDefaultAsync(x => x.HolidayId == holidayId);
            if (h == null) return null;

            return new HolidayDto
            {
                HolidayId = h.HolidayId,
                Date = h.Date,
                Name = h.Name,
                Region = null
            };
        }

        public async Task<HolidayDto> CreateAsync(HolidayDto dto)
        {
            var entity = new Holiday
            {
                Date = dto.Date,
                Name = dto.Name
                // no Region property on entity
            };

            _db.Holidays.Add(entity);
            await _db.SaveChangesAsync();

            return new HolidayDto
            {
                HolidayId = entity.HolidayId,
                Date = entity.Date,
                Name = entity.Name,
                Region = null
            };
        }

        public async Task<HolidayDto?> UpdateAsync(HolidayDto dto)
        {
            var entity = await _db.Holidays.FirstOrDefaultAsync(x => x.HolidayId == dto.HolidayId);
            if (entity == null) return null;

            entity.Date = dto.Date;
            entity.Name = dto.Name;
            // no Region on entity to update

            await _db.SaveChangesAsync();

            return new HolidayDto
            {
                HolidayId = entity.HolidayId,
                Date = entity.Date,
                Name = entity.Name,
                Region = null
            };
        }

        public async Task<bool> DeleteAsync(int holidayId)
        {
            var entity = await _db.Holidays.FirstOrDefaultAsync(x => x.HolidayId == holidayId);
            if (entity == null) return false;

            _db.Holidays.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}