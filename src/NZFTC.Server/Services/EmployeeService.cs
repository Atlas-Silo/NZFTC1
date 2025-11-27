// EmployeeService
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
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;

        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return await _db.Employees
                .AsNoTracking()
                .Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Role = e.Role,
                    DateHired = e.DateHired,
                    Salary = e.Salary
                })
                .ToListAsync();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int employeeId)
        {
            var e = await _db.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (e == null) return null;

            return new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Role = e.Role,
                DateHired = e.DateHired,
                Salary = e.Salary
            };
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            var entity = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Role = dto.Role,
                DateHired = dto.DateHired,
                Salary = dto.Salary
            };

            _db.Employees.Add(entity);
            await _db.SaveChangesAsync();

            return new EmployeeDto
            {
                EmployeeId = entity.EmployeeId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Role = entity.Role,
                DateHired = entity.DateHired,
                Salary = entity.Salary
            };
        }

        public async Task<EmployeeDto?> UpdateAsync(UpdateEmployeeDto dto)
        {
            var entity = await _db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == dto.EmployeeId);
            if (entity == null) return null;

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Email = dto.Email;
            entity.Role = dto.Role;
            entity.DateHired = dto.DateHired;
            entity.Salary = dto.Salary;

            await _db.SaveChangesAsync();

            return new EmployeeDto
            {
                EmployeeId = entity.EmployeeId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Role = entity.Role,
                DateHired = entity.DateHired,
                Salary = entity.Salary
            };
        }

        public async Task<bool> DeleteAsync(int employeeId)
        {
            var entity = await _db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (entity == null) return false;

            _db.Employees.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}