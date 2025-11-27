// TokenResponseDto
using System;
using System.Collections.Generic;

namespace NZFTC.Shared.Dtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = Array.Empty<string>();
    }
}