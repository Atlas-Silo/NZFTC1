using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NZFTC.EmployeeMgmt.MockServices.Dtos;

namespace NZFTC.EmployeeMgmt.MockServices.Interfaces
{
  public interface IGrievanceService
  {
    Task<GrievanceDto> SubmitGrievanceAsync(GrievanceDto request);
    Task<List<GrievanceDto>> GetGrievancesForAdminAsync();
  }
}