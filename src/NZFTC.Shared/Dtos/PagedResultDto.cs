// PagedResultDto
using System.Collections.Generic;

namespace NZFTC.Shared.Dtos
{
    public class PagedResultDto<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}