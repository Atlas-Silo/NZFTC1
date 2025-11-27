// UserDto
using System.Collections.Generic;

namespace NZFTC.Shared.Dtos
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = System.Array.Empty<string>();
    }
}