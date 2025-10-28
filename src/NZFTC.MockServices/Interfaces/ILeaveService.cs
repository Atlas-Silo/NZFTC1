using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.EmployeeMgmt.MockServices.Dtos;

namespace NZFTC.EmployeeMgmt.MockServices.Interfaces
{
  public interface ILeaveService
  {
    Task<LeaveRequestDto> CreateLeaveRequestAsync(LeaveRequestDto request);
    Task<List<LeaveRequestDto>> GetLeavesByUserIdAsync(Guid userId);
    Task ApproveLeaveAsync(Guid leaveId, Guid approverId);
  }
}