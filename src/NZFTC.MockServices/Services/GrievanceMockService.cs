using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZFTC.EmployeeMgmt.MockServices.Dtos;
using NZFTC.EmployeeMgmt.MockServices.Interfaces;

namespace NZFTC.EmployeeMgmt.MockServices.Services
{
  public class GrievanceMockService : IGrievanceService
  {
    private readonly List<GrievanceDto> _store = new();

    public Task<GrievanceDto> SubmitGrievanceAsync(GrievanceDto request)
    {
      request.Id = Guid.NewGuid();
      request.SubmittedAt = DateTime.UtcNow;
      request.Status = "Submitted";
      _store.Add(request);
      return Task.FromResult(request);
    }

    public Task<List<GrievanceDto>> GetGrievancesForAdminAsync()
    {
      return Task.FromResult(_store.ToList());
    }
  }
}