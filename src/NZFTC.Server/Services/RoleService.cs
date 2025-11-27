// src/NZFTC.Server/Services/RoleService.cs
using Microsoft.AspNetCore.Identity;
using NZFTC.Data.Entities;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZFTC.Server.Services
{
    public class RoleService : NZFTC.Shared.Interfaces.IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            await Task.CompletedTask;
            return _roleManager.Roles
                .Select(r => new RoleDto { Name = r.Name ?? string.Empty })
                .ToList();
        }

        public async Task CreateRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new Role { Name = roleName });
            }
        }

        public Task<bool> RoleExistsAsync(string roleName)
        {
            return _roleManager.RoleExistsAsync(roleName);
        }
    }
}