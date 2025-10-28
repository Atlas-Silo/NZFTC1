using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NZFTC.MockServices {
  public class LeaveMockService {
    public Task<List<object>> GetLeavesAsync() {
      return Task.FromResult(new List<object> { new { Id = Guid.NewGuid(), Reason = ""Sample leave"", Start = DateTime.UtcNow } });
    }
  }
}
