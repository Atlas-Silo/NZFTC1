// src/NZFTC.Server/Services/GrievanceService.cs
using Microsoft.EntityFrameworkCore;
using NZFTC.Data;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZFTC.Server.Services
{
    public class GrievanceService : IGrievanceService
    {
        private readonly AppDbContext _db;

        public GrievanceService(AppDbContext db) { _db = db; }

        public async Task<IEnumerable<GrievanceDto>> GetAllAsync()
        {
            return await _db.Grievances
                .AsNoTracking()
                .Select(g => new GrievanceDto
                {
                    GrievanceId = g.GrievanceId,
                    EmployeeId = g.EmployeeId,
                    SubmittedOn = g.SubmittedOn,
                    Subject = g.Subject,
                    Details = g.Details,
                    Status = g.Status
                })
                .ToListAsync();
        }

        public async Task<GrievanceDto?> GetByIdAsync(int grievanceId)
        {
            var g = await _db.Grievances.AsNoTracking().FirstOrDefaultAsync(x => x.GrievanceId == grievanceId);
            if (g == null) return null;
            return new GrievanceDto
            {
                GrievanceId = g.GrievanceId,
                EmployeeId = g.EmployeeId,
                SubmittedOn = g.SubmittedOn,
                Subject = g.Subject,
                Details = g.Details,
                Status = g.Status
            };
        }

        public async Task<GrievanceDto> CreateAsync(GrievanceDto dto)
        {
            var entity = new NZFTC.Data.Entities.Grievance
            {
                EmployeeId = dto.EmployeeId,
                SubmittedOn = dto.SubmittedOn == default ? System.DateTime.UtcNow : dto.SubmittedOn,
                Subject = dto.Subject,
                Details = dto.Details,
                Status = dto.Status
            };

            // ensure we call the DbSet add that expects the entity type
            _db.Set<NZFTC.Data.Entities.Grievance>().Add(entity);
            await _db.SaveChangesAsync();

            return new GrievanceDto
            {
                GrievanceId = entity.GrievanceId,
                EmployeeId = entity.EmployeeId,
                SubmittedOn = entity.SubmittedOn,
                Subject = entity.Subject,
                Details = entity.Details,
                Status = entity.Status
            };
        }

        public async Task<GrievanceDto?> UpdateAsync(GrievanceDto dto)
        {
            var entity = await _db.Grievances.FirstOrDefaultAsync(x => x.GrievanceId == dto.GrievanceId);
            if (entity == null) return null;

            entity.Subject = dto.Subject;
            entity.Details = dto.Details;
            entity.Status = dto.Status;

            await _db.SaveChangesAsync();

            return new GrievanceDto
            {
                GrievanceId = entity.GrievanceId,
                EmployeeId = entity.EmployeeId,
                SubmittedOn = entity.SubmittedOn,
                Subject = entity.Subject,
                Details = entity.Details,
                Status = entity.Status
            };
        }

        public async Task<bool> DeleteAsync(int grievanceId)
        {
            var entity = await _db.Grievances.FirstOrDefaultAsync(x => x.GrievanceId == grievanceId);
            if (entity == null) return false;
            _db.Grievances.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}