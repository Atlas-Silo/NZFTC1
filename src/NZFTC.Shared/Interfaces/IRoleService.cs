// IRoleService
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.Shared.Dtos;

namespace NZFTC.Shared.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task CreateRoleAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
    }
}