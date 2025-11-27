// ErrorResponseDto
namespace NZFTC.Shared.Dtos
{
    public class ErrorResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public string? Details { get; set; }
    }
}