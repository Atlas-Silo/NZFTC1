using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZFTC.EmployeeMgmt.MockServices.Dtos;
using NZFTC.EmployeeMgmt.MockServices.Interfaces;

namespace NZFTC.EmployeeMgmt.MockServices.Services
{
  public class LeaveMockService : ILeaveService
  {
    private readonly List<LeaveRequestDto> _store = new();

    public Task<LeaveRequestDto> CreateLeaveRequestAsync(LeaveRequestDto request)
    {
      request.Id = Guid.NewGuid();
      request.Status = "Pending";
      _store.Add(request);
      return Task.FromResult(request);
    }

    public Task<List<LeaveRequestDto>> GetLeavesByUserIdAsync(Guid userId)
    {
      var list = _store.Where(x => x.UserId == userId).ToList();
      return Task.FromResult(list);
    }

    public Task ApproveLeaveAsync(Guid leaveId, Guid approverId)
    {
      var item = _store.FirstOrDefault(x => x.Id == leaveId);
      if (item != null) item.Status = "Approved";
      return Task.CompletedTask;
    }
  }
}