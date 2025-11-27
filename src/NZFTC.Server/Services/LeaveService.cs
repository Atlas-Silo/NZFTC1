// src/NZFTC.Server/Services/LeaveService.cs
using Microsoft.EntityFrameworkCore;
using NZFTC.Data;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZFTC.Server.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly AppDbContext _db;

        public LeaveService(AppDbContext db) { _db = db; }

        public async Task<IEnumerable<LeaveRequestDto>> GetAllAsync()
        {
            return await _db.LeaveRequests
                .AsNoTracking()
                .Select(l => new LeaveRequestDto
                {
                    LeaveRequestId = l.LeaveRequestId,
                    EmployeeId = l.EmployeeId,
                    StartDate = l.StartDate,
                    EndDate = l.EndDate,
                    Type = l.Type,
                    Status = l.Status,
                    RequestedOn = l.RequestedOn
                })
                .ToListAsync();
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId)
        {
            var l = await _db.LeaveRequests.AsNoTracking().FirstOrDefaultAsync(x => x.LeaveRequestId == leaveRequestId);
            if (l == null) return null;
            return new LeaveRequestDto
            {
                LeaveRequestId = l.LeaveRequestId,
                EmployeeId = l.EmployeeId,
                StartDate = l.StartDate,
                EndDate = l.EndDate,
                Type = l.Type,
                Status = l.Status,
                RequestedOn = l.RequestedOn
            };
        }

        public async Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto dto)
        {
            var entity = new NZFTC.Data.Entities.LeaveRequest
            {
                EmployeeId = dto.EmployeeId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Type = dto.Type,
                Status = "Pending",
                RequestedOn = dto.RequestedOn ?? System.DateTime.UtcNow
            };

            _db.Set<NZFTC.Data.Entities.LeaveRequest>().Add(entity);
            await _db.SaveChangesAsync();

            return new LeaveRequestDto
            {
                LeaveRequestId = entity.LeaveRequestId,
                EmployeeId = entity.EmployeeId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Type = entity.Type,
                Status = entity.Status,
                RequestedOn = entity.RequestedOn
            };
        }

        public async Task<LeaveRequestDto?> UpdateAsync(LeaveRequestDto dto)
        {
            var entity = await _db.LeaveRequests.FirstOrDefaultAsync(x => x.LeaveRequestId == dto.LeaveRequestId);
            if (entity == null) return null;

            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.Type = dto.Type;
            entity.Status = dto.Status;

            await _db.SaveChangesAsync();

            return new LeaveRequestDto
            {
                LeaveRequestId = entity.LeaveRequestId,
                EmployeeId = entity.EmployeeId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Type = entity.Type,
                Status = entity.Status,
                RequestedOn = entity.RequestedOn
            };
        }

        public async Task<bool> DeleteAsync(int leaveRequestId)
        {
            var entity = await _db.LeaveRequests.FirstOrDefaultAsync(x => x.LeaveRequestId == leaveRequestId);
            if (entity == null) return false;
            _db.LeaveRequests.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}