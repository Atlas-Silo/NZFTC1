// src/NZFTC.Server/Services/PayrollService.cs
using Microsoft.EntityFrameworkCore;
using NZFTC.Data;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZFTC.Server.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly AppDbContext _db;

        public PayrollService(AppDbContext db) { _db = db; }

        public async Task<IEnumerable<PayrollDto>> GetAllAsync()
        {
            return await _db.Payrolls
                .AsNoTracking()
                .Select(p => new PayrollDto
                {
                    PayrollId = p.PayrollId,
                    EmployeeId = p.EmployeeId,
                    PayPeriodStart = p.PayPeriodStart,
                    PayPeriodEnd = p.PayPeriodEnd,
                    GrossPay = p.GrossPay,
                    Tax = p.Tax,
                    NetPay = p.NetPay,
                    GeneratedOn = p.GeneratedOn
                })
                .ToListAsync();
        }

        public async Task<PayrollDto?> GetByIdAsync(int payrollId)
        {
            var p = await _db.Payrolls.AsNoTracking().FirstOrDefaultAsync(x => x.PayrollId == payrollId);
            if (p == null) return null;
            return new PayrollDto
            {
                PayrollId = p.PayrollId,
                EmployeeId = p.EmployeeId,
                PayPeriodStart = p.PayPeriodStart,
                PayPeriodEnd = p.PayPeriodEnd,
                GrossPay = p.GrossPay,
                Tax = p.Tax,
                NetPay = p.NetPay,
                GeneratedOn = p.GeneratedOn
            };
        }

        public async Task<PayrollDto> CreateAsync(CreatePayrollDto dto)
        {
            DateTime generated = dto.GeneratedOn ?? DateTime.UtcNow;

            var entity = new NZFTC.Data.Entities.Payroll
            {
                EmployeeId = dto.EmployeeId,
                PayPeriodStart = dto.PayPeriodStart,
                PayPeriodEnd = dto.PayPeriodEnd,
                GrossPay = dto.GrossPay,
                Tax = dto.Tax,
                NetPay = dto.NetPay,
                GeneratedOn = generated
            };

            _db.Set<NZFTC.Data.Entities.Payroll>().Add(entity);
            await _db.SaveChangesAsync();

            return new PayrollDto
            {
                PayrollId = entity.PayrollId,
                EmployeeId = entity.EmployeeId,
                PayPeriodStart = entity.PayPeriodStart,
                PayPeriodEnd = entity.PayPeriodEnd,
                GrossPay = entity.GrossPay,
                Tax = entity.Tax,
                NetPay = entity.NetPay,
                GeneratedOn = entity.GeneratedOn
            };
        }

        public async Task<PayrollDto?> UpdateAsync(PayrollDto dto)
        {
            var entity = await _db.Payrolls.FirstOrDefaultAsync(x => x.PayrollId == dto.PayrollId);
            if (entity == null) return null;

            entity.EmployeeId = dto.EmployeeId;
            entity.PayPeriodStart = dto.PayPeriodStart;
            entity.PayPeriodEnd = dto.PayPeriodEnd;
            entity.GrossPay = dto.GrossPay;
            entity.Tax = dto.Tax;
            entity.NetPay = dto.NetPay;
            entity.GeneratedOn = dto.GeneratedOn;

            await _db.SaveChangesAsync();

            return new PayrollDto
            {
                PayrollId = entity.PayrollId,
                EmployeeId = entity.EmployeeId,
                PayPeriodStart = entity.PayPeriodStart,
                PayPeriodEnd = entity.PayPeriodEnd,
                GrossPay = entity.GrossPay,
                Tax = entity.Tax,
                NetPay = entity.NetPay,
                GeneratedOn = entity.GeneratedOn
            };
        }

        public async Task<bool> DeleteAsync(int payrollId)
        {
            var entity = await _db.Payrolls.FirstOrDefaultAsync(x => x.PayrollId == payrollId);
            if (entity == null) return false;
            _db.Payrolls.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}